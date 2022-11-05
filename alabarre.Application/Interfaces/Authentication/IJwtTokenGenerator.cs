using alabarre.Domain.Entities;

namespace alabarre.Application.Intefaces.Authentication;

/* Interfaces Generateur de Token JWT */
public interface IJwtTokenGenerator {

    string GenerateToken(User user);
}