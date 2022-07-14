namespace FactoryPatternWithDependencyInjection.Models;

public interface IVehicleFactory
{
    IVehicle Create(string type);
}

public class VehicleFactory : IVehicleFactory
{
    private readonly Func<IEnumerable<IVehicle>> _factory;

    public VehicleFactory(Func<IEnumerable<IVehicle>> factory)
    {
        _factory = factory;
    }

    public IVehicle Create(string type)
    {
        var vehicles = _factory();
        var output = vehicles.Single(x => x.VehicleType.Equals(type));
        return output;
    }
}