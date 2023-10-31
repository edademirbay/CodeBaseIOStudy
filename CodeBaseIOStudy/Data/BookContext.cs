using CodeBaseIOStudy.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeBaseIOStudy.Data
{
    public class BookContext : DbContext
    {
        private readonly IConfiguration configuration;

        public BookContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(configuration.GetConnectionString("BookContext"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }



        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Book> Books { get; set; }

    }
}

