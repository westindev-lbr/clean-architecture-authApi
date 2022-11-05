using alabarre.Domain.Entities;

namespace alabarre.Application.Intefaces.Authentication;

/* Interfaces Generateur de Token JWT */
public interface IJwtTokenGenerator {

    // Méthodes 
    string GenerateToken(User user);
    //
}