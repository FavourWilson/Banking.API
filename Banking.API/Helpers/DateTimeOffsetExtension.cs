namespace Banking.API.Helpers
{
    public static class DateTimeOffsetExtension
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffset)
        {
            var currentAge = DateTime.UtcNow;
            int age = currentAge.Year - dateTimeOffset.Year;

            if (currentAge < dateTimeOffset.AddYears(age))
            {
                age--;
            }
            return age;
        }
    }
}
