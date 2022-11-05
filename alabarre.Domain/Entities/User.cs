namespace alabarre.Domain.Entities ;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int StudentNum { get; set; }
    public string Password { get; set; } = null!;
    public string Salt { get; set; } = null!;
    public DateTime DateCreation { get; set; }
    public DateTime LastLogin { get; set; }

}