namespace Fina.Core.Common;
//Extension Methods
public static class DateTimeExtension
{
    /// <summary>
    /// Retorna o primeiro dia do mês
    /// </summary>
    /// <param name="date">Qual dia</param>
    /// <param name="year">Qual ano</param>
    /// <param name="month">Qual mês</param>
    /// <returns></returns>
    public static DateTime GetFirstDay(this DateTime date, int? year=null, int? month = null)
        => new(year ?? date.Year, month ?? date.Month, 1);

    /// <summary>
    /// Retorna o ultimo dia do mês
    /// </summary>
    /// <param name="date">Qual dia</param>
    /// <param name="year">Qual ano</param>
    /// <param name="month">Qual mes</param>
    /// <returns></returns>
    public static DateTime GetLastDay(this DateTime date, int? year = null, int? month = null)
        => new DateTime(
            year ?? date.Year,
            month ?? date.Month,
            1).AddMonths(-1).AddDays(-1);
}
