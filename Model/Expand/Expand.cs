using System;

public static class Expand
{
    # region 字符串

    /// <summary>
    /// 固定长度字符串
    /// </summary>
    /// <param name="str"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string ToString(this string str, int length)
    {
        string result = str;
        if (str.Length > length)
        {
            result = str.Substring(0, length) + "...";
        }
        return result;
    }

    # endregion 字符串

    # region 时间

    /// <summary>
    /// 转换成字符串
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateTime ToShortDate(this DateTime dateTime)
    {
        return Convert.ToDateTime(dateTime.ToString("yyyy-MM-dd hh:mm:ss:fff"));
    }

    /// <summary>
    /// 转换成字符串
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateTime ToShortDate(this DateTime dateTime, string format)
    {
        return Convert.ToDateTime(dateTime.ToString(format));
    }

    /// <summary>
    /// 获取当前日期的前几天0时
    /// </summary>
    /// <param name="days">前几天(默认当天)</param>
    /// <returns></returns>
    public static DateTime GetDaysAgo(this DateTime dateTime, int days = 0)
    {
        var date = dateTime.AddDays(-1 * days);
        date = Convert.ToDateTime(string.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day));
        return date;
    }

    /// <summary>
    /// 获取当前日期的前几天0时
    /// </summary>
    /// <param name="months">前几月(默认本月)</param>
    /// <returns></returns>
    public static DateTime GetMonthsAgo(this DateTime dateTime, int months = 0)
    {
        var date = dateTime.AddMonths(-1 * months);
        date = Convert.ToDateTime(string.Format("{0}-{1}-{2}", date.Year, date.Month, 1));
        return date;
    }

    /// <summary>  
    /// 得到本周第一天(以星期天为第一天)  
    /// </summary>  
    /// <param name="datetime"></param>  
    /// <returns></returns>  
    public static DateTime GetWeekFirstDaySun(this DateTime datetime)
    {
        //星期天为第一天  
        int weeknow = Convert.ToInt32(datetime.DayOfWeek);
        int daydiff = (-1) * weeknow;

        //本周第一天  
        string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
        return Convert.ToDateTime(FirstDay);
    }

    /// <summary>  
    /// 得到本周第一天(以星期一为第一天)  
    /// </summary>  
    /// <param name="datetime"></param>  
    /// <returns></returns>  
    public static DateTime GetWeekFirstDayMon(this DateTime datetime)
    {
        //星期一为第一天  
        int weeknow = Convert.ToInt32(datetime.DayOfWeek);

        //因为是以星期一为第一天，所以要判断weeknow等于0时，要向前推6天。  
        weeknow = (weeknow == 0 ? (7 - 1) : (weeknow - 1));
        int daydiff = (-1) * weeknow;

        //本周第一天  
        string FirstDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
        return Convert.ToDateTime(FirstDay);
    }

    /// <summary>  
    /// 得到本周最后一天(以星期六为最后一天)  
    /// </summary>  
    /// <param name="datetime"></param>  
    /// <returns></returns>  
    public static DateTime GetWeekLastDaySat(this DateTime datetime)
    {
        //星期六为最后一天  
        int weeknow = Convert.ToInt32(datetime.DayOfWeek);
        int daydiff = (7 - weeknow) - 1;

        //本周最后一天
        string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
        return Convert.ToDateTime(LastDay);
    }

    /// <summary>  
    /// 得到本周最后一天(以星期天为最后一天)  
    /// </summary>  
    /// <param name="datetime"></param>  
    /// <returns></returns>  
    public static DateTime GetWeekLastDaySun(this DateTime datetime)
    {
        //星期天为最后一天  
        int weeknow = Convert.ToInt32(datetime.DayOfWeek);
        weeknow = (weeknow == 0 ? 7 : weeknow);
        int daydiff = (7 - weeknow);

        //本周最后一天  
        string LastDay = datetime.AddDays(daydiff).ToString("yyyy-MM-dd");
        return Convert.ToDateTime(LastDay);
    }

    # endregion 时间

    # region demical

    /// <summary>
    /// 保留指定位数的小数
    /// </summary>
    /// <param name="dvalue">数值</param>
    /// <param name="le">保留位数(默认2位)</param>
    /// <param name="RoundUp">是否四舍五入(默认舍去后面的值)</param>
    /// <returns></returns>
    public static string ToFixedString(this decimal dvalue, int le = 2)
    {
        return Math.Round(dvalue, le).ToString();
    }

    /// <summary>
    /// 转换成百分比形式
    /// </summary>
    /// <param name="dvalue">数值</param>
    /// <param name="le">保留位数(默认2位)</param>
    /// <param name="RoundUp">是否四舍五入(默认舍去后面的值)</param>
    /// <returns></returns>
    public static string ToPercent(this decimal dvalue, int le = 2)
    {
        decimal value = Math.Round(dvalue, le);
        return value + "%";
    }

    /// <summary>
    /// 保留指定位数的小数
    /// </summary>
    /// <param name="dvalue">数值</param>
    /// <param name="le">保留位数(默认2位)</param>
    /// <param name="RoundUp">是否四舍五入(默认舍去后面的值)</param>
    /// <returns></returns>
    public static decimal ToFixedDecimal(this decimal dvalue, int le = 2)
    {
        return Math.Round(dvalue, le);
    }

    # endregion demical
}