using Banking.API.DbContexts;
using Banking.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
