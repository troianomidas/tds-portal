using System.Globalization;

namespace WebApp.Utils;

public struct CurrencyUtils
{
    public static decimal MoneyFormat(string? unitPrice)
    {
        return decimal.Parse(unitPrice ?? "0", NumberStyles.Currency, new CultureInfo("pt-BR"));
    }
    
    public static string MoneyFormat(decimal value)
    {
        return value.ToString("C", new CultureInfo("pt-BR"));
    }

    public static string? MoneyWithoutCurrency(decimal value)
    {
        return value < 0 ? null : MoneyFormat(value).Replace("R$", "").TrimStart().TrimEnd();
    }
}