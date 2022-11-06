using System.ComponentModel.DataAnnotations;

namespace alabarre.Contracts.Authentication;

public record LoginRequest(
    [Required] string Email,
    [Required] string Password);
