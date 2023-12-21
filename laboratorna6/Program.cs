using System;

class Worker
{
    public string FullName { get; set; }
    public string HomeCity { get; set; }
    public DateTime StartDate { get; set; }
    public Company WorkPlace { get; set; }

    public Worker() { }

    public Worker(string fullName, string homeCity, DateTime startDate, Company workPlace)
    {
        FullName = fullName;
        HomeCity = homeCity;
        StartDate = startDate;
        WorkPlace = workPlace;
    }

    public Worker(Worker otherWorker)
    {
        FullName = otherWorker.FullName;
        HomeCity = otherWorker.HomeCity;
        StartDate = otherWorker.StartDate;
        WorkPlace = otherWorker.WorkPlace;
    }

    public int GetWorkExperience()
    {
        DateTime currentDate = DateTime.Now;
        int monthsOfWork = (currentDate.Year - StartDate.Year) * 12 + currentDate.Month - StartDate.Month;
        return monthsOfWork;
    }

    public bool LivesNotFarFromTheMainOffice()
    {
        return HomeCity == WorkPlace.MainOfficeCity;
    }

    public override string ToString()
    {
        return $"{FullName}, {HomeCity}, {StartDate}, {WorkPlace}";
    }
}

class Company
{
    public string Name { get; set; }
    public string MainOfficeCity { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }
    public bool IsFullTimeEmployee { get; set; }

    public Company() { }

    public Company(string name, string mainOfficeCity, string position, double salary, bool isFullTimeEmployee)
    {
        Name = name;
        MainOfficeCity = mainOfficeCity;
        Position = position;
        Salary = salary;
        IsFullTimeEmployee = isFullTimeEmployee;
    }

    public Company(Company otherCompany)
    {
        Name = otherCompany.Name;
        MainOfficeCity = otherCompany.MainOfficeCity;
        Position = otherCompany.Position;
        Salary = otherCompany.Salary;
        IsFullTimeEmployee = otherCompany.IsFullTimeEmployee;
    }

    public override string ToString()
    {
        return $"{Name}, {MainOfficeCity}, {Position}, {Salary}, {IsFullTimeEmployee}";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть кількість працівників: ");
        int n = int.Parse(Console.ReadLine());

        Worker[] workers = new Worker[n];

        for (int i = 0; i < n; i++)
        {
            workers[i] = CreateWorker();
        }

        Console.WriteLine("\nІнформація про працівників:");
        PrintAllWorkers(workers);
    }

    static Worker CreateWorker()
    {
        Console.WriteLine("\nВведіть дані про працівника:");
        Console.Write("ПІБ: ");
        string fullName = Console.ReadLine();
        Console.Write("Місто проживання: ");
        string homeCity = Console.ReadLine();
        Console.Write("Дата початку роботи (yyyy-MM-dd): ");
        DateTime startDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("\nВведіть дані про компанію:");
        Company company = CreateCompany();

        return new Worker(fullName, homeCity, startDate, company);
    }

    static Company CreateCompany()
    {
        Console.Write("Назва компанії: ");
        string name = Console.ReadLine();
        Console.Write("Місто головного офісу: ");
        string mainOfficeCity = Console.ReadLine();
        Console.Write("Посада: ");
        string position = Console.ReadLine();
        Console.Write("Зарплата: ");
        double salary = double.Parse(Console.ReadLine());
        Console.Write("Працює на повний робочий день? (true/false): ");
        bool isFullTimeEmployee = bool.Parse(Console.ReadLine());

        return new Company(name, mainOfficeCity, position, salary, isFullTimeEmployee);
    }

    static void PrintAllWorkers(Worker[] workers)
    {
        foreach (var worker in workers)
        {
            Console.WriteLine(worker);
        }
    }
}
