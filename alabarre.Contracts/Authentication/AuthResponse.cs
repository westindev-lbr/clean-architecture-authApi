namespace alabarre.Contracts.Authentication;

public record AuthResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    int StudentNum,
    string Token
);