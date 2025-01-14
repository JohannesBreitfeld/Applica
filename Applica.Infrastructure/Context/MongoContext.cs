using Applica.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Applica.Infrastructure.Context
{
    public class MongoContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<ContactPerson> ContactPeople { get; set; }

        public DbSet<ActivityCategory> ActivityCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "mongodb://localhost:27017/";
            var collection = "johannesbreitfeld";

            optionsBuilder.UseMongoDB(connectionString, collection);
        }
    }
}
