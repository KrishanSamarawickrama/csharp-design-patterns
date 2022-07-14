namespace FactoryPatternWithDependencyInjection.Models;

public interface IRandomNumSample
{
    int RandomValue { get; set; }
}

public class RandomNumSample : IRandomNumSample
{
    public int RandomValue { get; set; } = Random.Shared.Next(1, 100);
}