namespace FactoryPatternWithDependencyInjection.Models;

public class EmployeeFactory : IEmployeeFactory
{
    private readonly Func<IEmployee> _factory;

    public EmployeeFactory(Func<IEmployee> factory)
    {
        _factory = factory;
    }

    public IEmployee Create(string name, decimal salary)
    {
        var obj = _factory();
        obj.Name = name;
        obj.Salary = salary;

        return obj;
    }
}

public interface IEmployeeFactory
{
    IEmployee Create(string name, decimal salary);
}