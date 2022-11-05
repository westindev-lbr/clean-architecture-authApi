using alabarre.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace alabarre.Infrastructure.Repository;

public class SqLiteDbContext : DbContext
{
    public SqLiteDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }

}
