using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using alabarre.Application.Intefaces.Authentication;
using alabarre.Application.Intefaces.Utiles;
using alabarre.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace alabarre.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{

    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;
    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(User user)
    {

        var signingCredentials = new SigningCredentials(
            // encodage de notre clé secrete de 16 bytes pour la signature avec notre clé secrete
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        // Création des claims pour le payload de notre token
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        // Configure le token avec nos 2 parties ; Signature & Payload ainsi que quelques paramètres en +
        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpirationTimeMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        // Retourne et serialize notre JWT Token en JWT compact
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
} 