using System.ComponentModel.DataAnnotations;

namespace alabarre.Contracts.Authentication;

public record RegisterRequest(
    [Required] string FirstName,
    [Required] string LastName,
    [Required] string Email,
    [Required] int StudentNum,
    [Required] string Password
);
