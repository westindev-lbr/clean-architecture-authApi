namespace alabarre.Application.Services.Authentication;

public interface IAuthService{
    AuthResult Register(int studentNum, string email, string firstName, string lastName, string password);
    AuthResult Login(string email, string password);
}