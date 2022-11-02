namespace alabarre.Application.Services.Authentication;

public class AuthService : IAuthService
{
    public AuthResult Login(int studentNum, string email, string password)
    {
        return new AuthResult(Guid.NewGuid(), "firstName", "lastName", email, studentNum, "token");
    }

    public AuthResult Register(
        int studentNum,
        string email,
        string firstName,
        string lastName,
        string password
    )
    {
        return new AuthResult(Guid.NewGuid(), firstName, lastName, email, studentNum, "token");
    }
}
