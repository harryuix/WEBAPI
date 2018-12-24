using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
namespace WebServer.Models
{
    class SakilaDbContext : DbContext {
        public SakilaDbContext(DbContextOptions<SakilaDbContext> options)
        : base(options) { }

        public DbSet<Actor> Actor {get; set;}
        //DbSet<T> type properties for other domain models
    }

    class SakilaDbContextFactory{
        public static SakilaDbContext Create(string connectionString) {
            var optionBuilder = new DbContextOptionsBuilder<SakilaDbContext>();
            optionBuilder.UseMySQL(connectionString);
            var SakilaDbContext = new SakilaDbContext(optionBuilder.Options);
            return SakilaDbContext;
        }
    } 
}