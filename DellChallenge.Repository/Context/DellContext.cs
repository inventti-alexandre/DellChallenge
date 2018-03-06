using DellChallenge.Domain.Enitities;
using DellChallange.Repository.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DellChallange.Repository.Context
{
    public class DellContext : DbContext
    {
        public DbSet<Classification> Condominio { get; set; }
        public DbSet<User> Bloco { get; set; }
        public DbSet<Gender> Usuario { get; set; }
        public DbSet<Client> Apartamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new ClassificationMap());
            modelBuilder.ApplyConfiguration(new GenderMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
