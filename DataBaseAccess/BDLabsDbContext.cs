using Microsoft.EntityFrameworkCore;
using Model;

namespace DataBaseAccess
{
    public class BDLabsDbContext : DbContext
    {
        public const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=Course;Trusted_Connection=True;";
        public BDLabsDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<OrderedBook> OrderedBooks { get; set; }
    }
}