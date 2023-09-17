using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace Infrastructure.Context;

public class MSDBcontext : DbContext
{
    public MSDBcontext() : base() { }

    public MSDBcontext(DbContextOptions<MSDBcontext> options)
        : base(options) {}

    public DbSet<Department> Departments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserDetails> UserDetails { get; set; }  
    public DbSet<EmployeeDetails> EmployeeDetails { get; set; } 

    public object T { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer
            ("Server=localhost;Database=ASALProject;User Id=sa;Password=reallyStrongPwd123;TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.UserRole)
            .WithMany(ur => ur.Users)
            .HasForeignKey(u => u.RoleId);

        modelBuilder.Entity<EmployeeDetails>()
            .HasOne(ed => ed.Department)
            .WithMany(d => d.EmployeeDetails) 
            .HasForeignKey(ed => ed.DepartmentId);
    }
}
