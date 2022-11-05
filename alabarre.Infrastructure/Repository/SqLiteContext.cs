using alabarre.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace alabarre.Infrastructure.Repository;

public partial class SqLiteContext : DbContext
{
    public SqLiteContext() { }

    public SqLiteContext(DbContextOptions<SqLiteContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(u => u.Id).HasColumnType("uniqueidentifier");
            entity.Property(u => u.FirstName).HasColumnType("VARCHR(50)");
            entity.Property(u => u.LastName).HasColumnType("VARCHR(50)");
            entity.Property(u => u.Email).HasColumnType("VARCHR(255)");
            entity.Property(u => u.StudentNum).HasColumnType("int");
            entity.Property(u => u.Password).HasColumnType("VARCHR(255)");
            entity.Property(u => u.Salt).HasColumnType("VARCHR(50)");
            entity.Property(u => u.DateCreation).HasColumnType("datetimeoffset");
            entity.Property(u => u.LastLogin).HasColumnType("datetimeoffset");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
