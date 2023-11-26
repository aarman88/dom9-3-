using System;

public class Employee
{
    protected string name;
    protected int age;
    protected double salary;

    public Employee(string name, int age, double salary)
    {
        this.name = name;
        this.age = age;
        this.salary = salary;
    }

    public virtual void GetInfo()
    {
        Console.WriteLine($"Имя: {name}, Возраст: {age}, Зарплата: {salary}");
    }

    public virtual double CalculateAnnualSalary()
    {
        return salary * 12;
    }
}

public class Manager : Employee
{
    private double bonus;

    public Manager(string name, int age, double salary, double bonus)
        : base(name, age, salary)
    {
        this.bonus = bonus;
    }

    public override void GetInfo()
    {
        base.GetInfo();
        Console.WriteLine($"Бонус: {bonus}");
    }

    public override double CalculateAnnualSalary()
    {
        return base.CalculateAnnualSalary() + bonus;
    }
}

public class Developer : Employee
{
    private int linesOfCodePerDay;
    private double ratePerLineOfCode = 0.1;

    public Developer(string name, int age, double salary, int linesOfCodePerDay)
        : base(name, age, salary)
    {
        this.linesOfCodePerDay = linesOfCodePerDay;
    }

    public override void GetInfo()
    {
        base.GetInfo();
        Console.WriteLine($"Строк кода в день: {linesOfCodePerDay}");
    }

    public override double CalculateAnnualSalary()
    {
        return base.CalculateAnnualSalary() + linesOfCodePerDay * ratePerLineOfCode * 250; // 250 - количество рабочих дней в году
    }
}

class Program
{
    static void Main()
    {
        Manager manager = new Manager("Alice Smith", 35, 80000, 5000);
        manager.GetInfo();

        Developer developer = new Developer("Bob Johnson", 28, 70000, 100);
        developer.GetInfo();

        double managerAnnualSalary = manager.CalculateAnnualSalary();
        Console.WriteLine($"Годовая зарплата менеджера: {managerAnnualSalary}");

        double developerAnnualSalary = developer.CalculateAnnualSalary();
        Console.WriteLine($"Годовая зарплата разработчика: {developerAnnualSalary}");
    }
}
