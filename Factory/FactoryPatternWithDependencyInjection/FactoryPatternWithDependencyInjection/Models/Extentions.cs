namespace FactoryPatternWithDependencyInjection.Models;

public static class Extentions
{
    public static void AddAbstractFactory<TInterface,TImplementation>(this IServiceCollection services) 
        where TInterface : class 
        where TImplementation : class, TInterface
    {
        services.AddTransient<TInterface, TImplementation>();
        services.AddSingleton<Func<TInterface>>(x => () => x.GetService<TInterface>()!);
        services.AddSingleton<IAbstractFactory<TInterface>, AbstractFactory<TInterface>>();
    }

    public static void AddEmployeeFactory(this IServiceCollection services)
    {
        services.AddTransient<IEmployee, Employee>();
        services.AddSingleton<Func<IEmployee>>(x => () => x.GetService<IEmployee>()!);
        services.AddSingleton<IEmployeeFactory, EmployeeFactory>();
    }
    
    public static void AddVehicleFactory(this IServiceCollection services)
    {
        services.AddTransient<IVehicle, Car>();
        services.AddTransient<IVehicle, Van>();
        services.AddTransient<IVehicle, Tuk>();

        services.AddSingleton<Func<IEnumerable<IVehicle>>>(x => () => x.GetService<IEnumerable<IVehicle>>()!);
        services.AddSingleton<IVehicleFactory, VehicleFactory>();
    }
}

