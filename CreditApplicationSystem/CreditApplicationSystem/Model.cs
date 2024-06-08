public class CreditApplication
{
    public Person Person { get; set; }
    public Passport Passport { get; set; }
    public Request Request { get; set; }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
}

public class Passport
{
    public string Serie { get; set; }
    public string Number { get; set; }
}

public class Request
{
    public decimal Summa { get; set; }
    public int Period { get; set; }
}
