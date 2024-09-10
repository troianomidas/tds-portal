namespace WebApp.Utils;

public struct DocumentUtils
{
    public static bool IsCpfValid(string? document)
    {
        int[] multi1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multi2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf, digito;
        int soma, resto;

        document = document?.Trim();
        document = document?.Replace(".", "").Replace("-", "");

        if (document?.Length != 11)
            return false;

        tempCpf = document.Substring(0, 9);
        soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multi1[i];

        resto = soma % 11;

        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();
        tempCpf += digito;
        soma = 0;

        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multi2[i];

        resto = soma % 11;

        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito += resto.ToString();

        return document.EndsWith(digito);
    }
}