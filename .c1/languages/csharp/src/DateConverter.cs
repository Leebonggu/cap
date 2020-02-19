using System;

namespace CapitalOne.WeatherTracker
{
  public class DateConverter
  {
    public static string ToString(DateTime date)
    {
      return date.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
    }
  }
}
