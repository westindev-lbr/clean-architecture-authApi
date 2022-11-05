using alabarre.Application.Intefaces.Authentication;
using alabarre.Application.Intefaces.Repository;
using alabarre.Application.Intefaces.Utiles;
using alabarre.Domain.Entities;

namespace alabarre.Application.Services.Authentication;

public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IHashPassword _hashPassword;

    // Injection du service de génération de Jwt Token
    public AuthService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository,
        IDateTimeProvider dateTimeProvider,
        IHashPassword hashPassword
    )
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _dateTimeProvider = dateTimeProvider;
        _hashPassword = hashPassword;
    }

    public AuthResult Login(string email, string password)
    {
        // Verifier si l'utilisateur existe
        var user = _userRepository.GetUserByEmail(email);

        if (user is not User u)
        {
            throw new Exception("Il semblerait qu'aucun utilisateur ne correspond à cet email");
        }

        // Vérifier mot de passe
        if (user.Password != _hashPassword.HashPasswd($"{password}{user.Salt}"))
        {
            throw new Exception("Mot de passe invalide");
        }

        user.LastLogin = _dateTimeProvider.UtcNow;
        Console.WriteLine(user.LastLogin);
        // Date dernière connexion
        _userRepository.UpdateUser(user);

        // Creer le token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(user, token);
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
        var isUserExist = _userRepository.GetUserByEmail(email);

        if (isUserExist != null)
        {
            throw new Exception("Il semblerait qu'un utilisateur avec cet email existe déjà!");
        }

        // Saler le mot de passe
        var salt = _hashPassword.GenerateSalt(16);
        // Hash de la concaténation du salt et du mot de passe
        var hashedAndSaltPwd = _hashPassword.HashPasswd($"{password}{salt}");



        // Créer un utilisateur
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            StudentNum = studentNum,
            Password = hashedAndSaltPwd,
            Salt = salt,
            DateCreation = _dateTimeProvider.UtcNow
        };

        _userRepository.Add(user);

        // Créer un Jwt Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(user, token);
    }
}
