namespace alabarre.Contracts.Authentication;

public record AuthResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string StudentNum,
    string Token
);