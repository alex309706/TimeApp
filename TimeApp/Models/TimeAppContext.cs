using Microsoft.EntityFrameworkCore;
namespace TimeApp.Models
{
    public class TimeAppContext:DbContext
    {
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Record> Records { get; set; }
        public TimeAppContext(DbContextOptions<TimeAppContext> options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(Localdb)\\mssqllocaldb;database=DbForTimeSpentApp;trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>().Property(record => record.SpentTime).HasComputedColumnSql("DATEDIFF(MINUTE,[BeginOfWork], [EndOfWork])");
        }

    }
}
