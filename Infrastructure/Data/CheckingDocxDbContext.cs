using Core.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CheckingDocxDbContext : DbContext
    {
        public CheckingDocxDbContext() : base() { }
        public CheckingDocxDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedRequirements();
            modelBuilder.SeedValues();

            modelBuilder.ApplyConfiguration(new RequirementConfigurations());
            modelBuilder.ApplyConfiguration(new ValueConfigurations());

            modelBuilder.ApplyConfiguration(new ValueConfigurations());

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connStr = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = CheckingDocx; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            optionsBuilder.UseSqlServer(connStr);
        }

        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Value> Values { get; set; }
    }
}
