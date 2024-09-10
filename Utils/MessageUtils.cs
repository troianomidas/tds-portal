namespace WebApp.Utils;

public struct InputMsg
{
    public const string Required = "Este campo é obrigatório.";
    public const string LengthMin8Max40 = "Este campo deve ter entre 8 e 40 caracteres.";
    public const string LengthMin6Max65 = "Este campo deve ter entre 6 e 65 caracteres.";
    public const string LengthMin4Max65 = "Este campo deve ter entre 4 e 65 caracteres.";
    public const string PhoneLength = "Este campo deve ter pelo menos 8 caracteres.";
    public const string LengthMin10Max40 = "Este campo deve ter entre 10 e 40 caracteres.";
    public const string LengthMin4Max25 = "Este campo deve ter entre 4 e 25 caracteres.";
    public const string PasswordDoesntMatch = "As senhas devem ser iguais.";
    public const string PasswordIsWeak = "A senha não pode ser fraca.";
    public const string InvalidEmail = "O email deve conter '@' e '.'. Exemplo: 'seuemail@dominio.com'.";
    public const string EmailAlreadyInUse = "Este email já está em uso.";
}