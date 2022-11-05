using alabarre.Domain.Entities;

namespace alabarre.Application.Services;

public interface IUserService
{
    List<User> GetAllUsers();
}
