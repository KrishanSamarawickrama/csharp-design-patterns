namespace FactoryPatternWithDependencyInjection.Models;

public interface IEmployee
{
    string Name { get; set; }
    decimal Salary { get; set; }
}

public class Employee : IEmployee
{
    public string Name { get; set; } = default!;
    public decimal Salary { get; set; } = default!;
}