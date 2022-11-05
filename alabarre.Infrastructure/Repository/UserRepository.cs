using alabarre.Application.Intefaces.Repository;
using alabarre.Domain.Entities;

namespace alabarre.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly SqLiteDbContext _userDbContext;

    public UserRepository(SqLiteDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }

    public void Add(User user)
    {
        _userDbContext.Users.Add(user);
        _userDbContext.SaveChanges();
    }

    public List<User> GetAllUsers()
    {
        return _userDbContext.Users.ToList();
    }

    public User? GetUserByEmail(string email)
    {
        return _userDbContext.Users.SingleOrDefault(u => u.Email == email);
    }

    public void UpdateUser(User user)
    {
        _userDbContext.Users.Update(user);
        _userDbContext.SaveChanges();
    }
}
