namespace alabarre.Contracts.Authentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string StudentNum,
    string Password
);