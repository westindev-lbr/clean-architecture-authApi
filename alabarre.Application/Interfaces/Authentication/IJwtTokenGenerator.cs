namespace alabarre.Application.Intefaces.Authentication;

/* Interfaces Generateur de Token JWT */
public interface IJwtTokenGenerator {

    // Méthodes 
    string GenerateToken(Guid userId, string email, string firstName, string lastName);
    //
}