using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DeutschAktiv.Core.Models
{
    public class DataContext : DbContext
    {
        public IConfigurationRoot Configuration { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DataContext() {
            var builder = new ConfigurationBuilder().AddJsonFile("config.json");
            Configuration = builder.Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration["Data:DefaultConnection:ConnectionString"]);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
