namespace alabarre.Contracts.Authentication;

public record LoginRequest(
    string Email,
    int StudentNum,
    string Password
);