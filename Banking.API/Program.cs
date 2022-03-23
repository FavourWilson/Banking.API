using Banking.API.DbContexts;
using Banking.API.JwtFeatures;
using Banking.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
       
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["ApplicationSettings:JWT_Secret"].ToString()))
    };
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        @"Server=DESKTOP-MD5FLS2\SQLEXPRESS; Initial Catalog = BankingDb; User ID = sa; Password = Nowayout@1"
        );
});
builder.Services.AddControllers(setupAction =>
{
    setupAction.ReturnHttpNotAcceptable = true;
})
  .AddXmlDataContractSerializerFormatters()
  .AddNewtonsoftJson(setupAction =>
  {
      setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
  })
  .ConfigureApiBehaviorOptions(setupAction =>
  {
      setupAction.InvalidModelStateResponseFactory = context =>
      {
          var problemDetailFactory = context.HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();
          var problemDetails = problemDetailFactory.CreateValidationProblemDetails(context.HttpContext, context.ModelState);
          problemDetails.Detail = "See the error field for details";
          problemDetails.Instance = context.HttpContext.Request.Path;

          var actionExecutingContext = context as ActionExecutingContext;
          if((context.ModelState.ErrorCount> 0) && (actionExecutingContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
          {
              problemDetails.Type = "https://BankingAPi.com/modelvalidationproblem";
              problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
              problemDetails.Title = "One or more validation errors";
              return new UnprocessableEntityObjectResult(problemDetails)
              {
                  ContentTypes = { "application/problem+json" }
              };
          };

          problemDetails.Status = StatusCodes.Status400BadRequest;
          problemDetails.Title = "One or more validation errors";
          return new UnprocessableEntityObjectResult(problemDetails)
          {
              ContentTypes = { "application/problem+json" }
          };

      };
  });
builder.Services.AddScoped<AccountRepository, AccountRepository>();
builder.Services.AddScoped<JwtHandler>();
builder.Services.AddIdentity<Banking.API.Entities.RegisterUser, IdentityRole>(
    options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
var app = builder.Build();
// Configure the HTTP request pipeline.
app.Use(async (ctx, next) =>
{
    await next();
    if(ctx.Response.StatusCode == 204)
    {
        ctx.Response.ContentLength = 0;
    }
});
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("ApplicationSettings:Client_Url")
.AllowAnyHeader()
.AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization(); 

app.MapControllers();

app.Run();
