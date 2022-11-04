using alabarre.Application.Intefaces.Authentication;

namespace alabarre.Application.Services.Authentication;

public class AuthService : IAuthService
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    // Injection du service de génération de Jwt Token
    public AuthService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthResult Login(
        int studentNum, 
        string email, 
        string password)
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
        // Vérifier si l'utilisateur existe déjà 

        // Créer un utilisateur : Générer un nouvel ID 
        Guid userId = Guid.NewGuid();

        // Hasher le mot de passe 

        // Saler le mot de passe 

        // Stocker la concaténation du salt et du mot de passe 

        // Créer un Jwt Token
        
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName, studentNum);
        
        return new AuthResult(
            userId, 
            firstName, 
            lastName, 
            email, 
            studentNum, 
            token);
    }
}
