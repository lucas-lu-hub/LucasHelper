namespace System;

public static class DateTimeExtensions
{
    public static IEnumerable<DateTime> EachDay(this DateTime from, DateTime end)
    {
        for (var day = from.Date; day.Date <= end.Date; day = day.AddDays(1))
        {
            yield return day;
        }
    }

    public static string ToUtcString(this DateTime date)
    {
        return date.ToUniversalTime()
                 .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
    }

    public static DateTime SetSeconds(this DateTime dateTime, int seconds)
    {
        seconds = seconds < 0 ? 0 : seconds;
        return dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute).AddSeconds(seconds);
    }

    /// <summary>
    /// 移除datetime的 日、时、分、秒
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>这一月的第一天</returns>
    public static DateTime RemoveDay(this DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, 1);
    }

    /// <summary>
    /// 移除 月、日、时、分、秒
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns>这一年的第一天</returns>
    public static DateTime RemoveMonthDay(this DateTime dateTime)
    {
        return new DateTime(dateTime.Year, 1, 1);
    }
}
