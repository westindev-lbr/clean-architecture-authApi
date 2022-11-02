namespace alabarre.Contracts.Authentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    int StudentNum,
    string Password
);