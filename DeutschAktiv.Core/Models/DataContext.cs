using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DeutschAktiv.Core.Models
{
    public class DataContext : DbContext
    {
        public IConfigurationRoot Configuration { get; set; }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ScheduleItem> Schedule { get; set; }

//        public DataContext() {
//            var builder = new ConfigurationBuilder().AddJsonFile("config.json");
//            Configuration = builder.Build();
//        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(Configuration["Data:DefaultConnection:ConnectionString"]);
            optionsBuilder.UseSqlite("Filename=./deutschaktiv.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
