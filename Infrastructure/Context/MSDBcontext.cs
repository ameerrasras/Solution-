using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

    public class MSDBcontext : DbContext
    {
        public MSDBcontext() : base() { }

        public MSDBcontext(DbContextOptions<MSDBcontext> options)
            : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

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
        }
    }