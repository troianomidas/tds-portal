namespace WebApp.Models;

public class LoginResponse
{
    public bool IsVerificationRequired { get; set; }
    public UserModel? User { get; set; }
}