namespace alabarre.Application.Services.Authentication;

public record AuthResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    int StudentNum,
    string Token
);