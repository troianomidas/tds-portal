using System.Globalization;

namespace WebApp.Utils;

public struct CustomerUtils
{
    public static long GetPhone(string? phone)
    {
        return string.IsNullOrEmpty(phone) ? 0 : Convert.ToInt64(string.Concat(phone.Where(char.IsDigit)));
    }

    public static string GetPhone(long phone)
    {
        return Convert.ToUInt64(phone).ToString(phone.ToString().Length == 11 ? @"(00) 00000-0000" : @"(00) 0000-0000");
    }

    public static long GetDocument(string? document)
    {
        return string.IsNullOrEmpty(document) ? 0 : Convert.ToInt64(string.Concat(document.Where(char.IsDigit)));
    }
    
    public static string? FirstCharToUpper(string? input)
    {
        if (string.IsNullOrEmpty(input))
            return null;
        
        TextInfo textInfo = new CultureInfo("pt-BR", false).TextInfo;
        return textInfo.ToTitleCase(input!.ToLower() ?? string.Empty);
    }
}