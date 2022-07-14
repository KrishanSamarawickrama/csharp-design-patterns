using System.Globalization;

namespace FactoryPatternWithDependencyInjection.Models;

public interface IDateTimeSample1
{
    string CurrentDateTime { get; set; }
}

public class DateTimeSample1 : IDateTimeSample1
{
    public string CurrentDateTime { get; set; } = DateTime.Now.ToString();
}