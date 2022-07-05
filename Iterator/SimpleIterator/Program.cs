using System.Collections;


var collection = new DaysInMonthCollection();
foreach (var item in collection)
{
    Console.WriteLine($"{item.Date} || {item.Days}");
}


class MonthsWithDays
{
    public string? Date { get; set; }
    public int Days { get; set; }
}

class DaysInMonthEnumerator : IEnumerator<MonthsWithDays>
{
    private int year = 1;
    private int month = 0;
    
    public bool MoveNext()
    {
        month++;
        if (month > 12)
        {
            month = 1;
            year++;
        }
        return year < 5;
    }

    public void Reset()
    {
        month = 0;
        year = 1;
    }

    public MonthsWithDays Current => new MonthsWithDays()
    {
        Date = $"{year.ToString().PadLeft(4,'0')}-{month}",
        Days = DateTime.DaysInMonth(year,month)
    };

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }
}

class DaysInMonthCollection : IEnumerable<MonthsWithDays>
{
    public IEnumerator<MonthsWithDays> GetEnumerator()
    {
        return new DaysInMonthEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}