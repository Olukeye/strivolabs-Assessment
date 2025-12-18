using Microsoft.EntityFrameworkCore;
using strivolabs_Assessment.Entities;

namespace strivolabs_Assessment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Service> Services => Set<Service>();
        public DbSet<ServiceToken> ServiceTokens => Set<ServiceToken>();
        public DbSet<Subscriber> Subscribers => Set<Subscriber>();

        public static class ServiceSeeder
        {
            public static void Seed(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Service>().HasData(
                    new Service
                    {
                        Id = 1,
                        ServiceId = "Naija_PROMO_001",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123"),
                        CreatedAt = DateTime.UtcNow
                    }
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasIndex(x => x.ServiceId).IsUnique();
            });

            modelBuilder.Entity<ServiceToken>(entity =>
            {
                entity.HasIndex(x => x.Token).IsUnique();
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.HasIndex(x => new { x.ServiceId, x.PhoneNumber }).IsUnique();
            });

            ServiceSeeder.Seed(modelBuilder);
        }
    }
}
