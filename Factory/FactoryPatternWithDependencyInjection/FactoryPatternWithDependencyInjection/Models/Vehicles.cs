namespace FactoryPatternWithDependencyInjection.Models;

public interface IVehicle
{
    string VehicleType { get; set; }
    string Start();
}

public class Car : IVehicle
{
    public string VehicleType { get; set; } = "Car";

    public string Start()
    {
        return $"The {nameof(Car)} has started !!";
    }
}

public class Tuk : IVehicle
{
    public string VehicleType { get; set; } = "Tuk";

    public string Start()
    {
        return $"The {nameof(Tuk)} has started !!";
    }
}

public class Van : IVehicle
{
    public string VehicleType { get; set; } = "Van";

    public string Start()
    {
        return $"The {nameof(Van)} has started !!";
    }
}