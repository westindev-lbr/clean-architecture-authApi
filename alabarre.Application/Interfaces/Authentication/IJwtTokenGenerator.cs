namespace alabarre.Application.Intefaces.Authentication;

/* Interfaces Generateur de Token JWT */
public interface IJwtTokenGenerator {

    // Méthodes 
    string GenerateToken(Guid userId, string firstName, string lastName, int studentNum);
    //
}