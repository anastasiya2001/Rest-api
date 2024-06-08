namespace CreditApplicationSystem
{
    public class DataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.BlacklistedPeople.Any())
            {
                context.BlacklistedPeople.AddRange(
                    new BlacklistedPerson { PassportSeries = "0311", PassportNumber = "123456" },
                    // Добавьте другие записи по необходимости
                );
                context.SaveChanges();
            }

            if (!context.PassportDatas.Any())
            {
                context.PassportDatas.AddRange(
                    new PassportData { FirstName = "Иван", LastName = "Иванов", Birthdate = new DateTime(2012, 4, 23), PassportSeries = "0311", PassportNumber = "123456" },
                    // Добавьте другие записи по необходимости
                );
                context.SaveChanges();
            }
        }
    }
}
