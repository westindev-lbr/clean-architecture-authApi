using alabarre.Domain.Entities;

namespace alabarre.Application.Intefaces.Repository;

public interface IUserRepository {
    // Récupère un utilisateur par son mail
    User? GetUserByEmail(string email);
    // Ajoute un utilisateur
    void Add(User user);
}