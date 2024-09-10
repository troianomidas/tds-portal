namespace WebApp.Utils;

public struct DateTimeUtils
{
    public static DateTime Now() => DateTime.Now;
    public static string GetFormattedDiffTime(DateTime a)
    {
        TimeSpan ts = DateTimeUtils.Now() - a;
        
        if (ts.TotalHours < 1)
        {
            if (ts.Minutes < 2)
                return "agora pouco";

            return ts.Minutes + " min atrás";
        }

        if (ts.TotalHours is >= 1 and < 2)
            return ts.Hours + " hora atrás";

        if (Math.Round(ts.TotalHours, 2) is >= 2 and <= 48)
            return Math.Round(ts.TotalHours) + " horas atrás";

        if (DateTimeUtils.Now().Year == a.Year) 
            return a.ToString("dddd, dd/MM");

        return a.ToString("dddd, dd/MM/yy");
    }
    
    public static string FinancialLayout(DateTime d) => $"{d.ToString("MMMM")} de {d.ToString("yyyy")}";

    public static string OrderLayout(DateTime d) => $"{d.ToString("dd")} de {d.ToString("MMM")}";
    
    public static string PeriodLayout(DateTime d)
    {
        if (d.Date == DateTimeUtils.Now().Date)
            return $"Hoje, {d.ToString("dd")} de {d.ToString("MMM")}";

        if (d.Date == DateTimeUtils.Now().Date.AddDays(1))
            return $"Amanhã, {d.ToString("dd")} de {d.ToString("MMM")}";
        
        return $"{d.ToString("dd")} de {d.ToString("MMM")}";
    } 
}