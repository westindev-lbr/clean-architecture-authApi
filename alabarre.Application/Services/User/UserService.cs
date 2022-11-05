using alabarre.Application.Intefaces.Repository;
using alabarre.Domain.Entities;

namespace alabarre.Application.Services;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> GetAllUsers()
    {
        var users = _userRepository.GetAllUsers();
        return users;
    }
}
