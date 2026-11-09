using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CapstoneProject.Data
{
    public class CapstoneProjectDbContextFactory : IDesignTimeDbContextFactory<CapstoneProjectDbContext>
    {
        public CapstoneProjectDbContext CreateDbContext(string[] args)
        {
            // Build configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../CapstoneProject")))
                //.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Get connection string
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configure DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<CapstoneProjectDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CapstoneProjectDbContext(optionsBuilder.Options);
        }
    }
}