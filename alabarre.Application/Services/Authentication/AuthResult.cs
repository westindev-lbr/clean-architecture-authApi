using alabarre.Domain.Entities;

namespace alabarre.Application.Services.Authentication;

public record AuthResult(
    User User,
    string Token
);