using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using alabarre.Application.Intefaces.Authentication;
using alabarre.Application.Intefaces.Utiles;
using Microsoft.IdentityModel.Tokens;

namespace alabarre.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{

    private readonly IDateTimeProvider _dateTimeProvider;
    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(Guid userId, string firstName, string lastName, int studentNum)
    {

        var signingCredentials = new SigningCredentials(
            // encodage de notre clé secrete de 16 bytes pour la signature avec notre clé secrete
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("alabarre_#paris8")),
            SecurityAlgorithms.HmacSha256);

        // Création des claims pour le payload de notre token
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        // Configure le token avec nos 2 parties ; Signature & Payload ainsi que quelques paramètres en +
        var securityToken = new JwtSecurityToken(
            issuer: "alabarre-api-auth",
            expires: _dateTimeProvider.UtcNow.AddMinutes(60),
            claims: claims,
            signingCredentials: signingCredentials);

        // Retourne et serialize notre JWT Token en JWT compact
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
} 