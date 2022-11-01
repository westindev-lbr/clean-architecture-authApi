namespace alabarre.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string StudentNum,
    string Password
);