namespace CapitalOne.WeatherTracker.Statistics
{
  public class Statistic
  {
    public Statistic(string metric, string stat, double value)
    {
      this.Metric = metric;
      this.Stat = stat;
      this.Value = value;
    }

    public string Metric { get; }

    public string Stat { get; }

    public double Value { get; }
  }
}
