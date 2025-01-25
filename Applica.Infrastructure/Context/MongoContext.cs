using Applica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Applica.Infrastructure.Context
{
    public class MongoContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<ActivityCategory> ActivityCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<MongoContext>().Build();
            
            var connectionString = config["ConnectionString"];

            var collection = "johannesbreitfeld";

            optionsBuilder.UseMongoDB(connectionString!, collection);
       

        }
    }
}
