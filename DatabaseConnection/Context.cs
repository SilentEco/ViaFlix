using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

namespace DatabaseConnection
{
    public class Context : DbContext
    {
        //Sätter alla tables från VS till databasen.

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Genre> Genres { get; set; }


        //Connectar till databasen
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                .UseLazyLoadingProxies()
                .UseSqlServer(
                @"server=.\SQLExpress;" +
                @"database=SaleDatabase;" +
                @"trusted_connection=true;" +
                @"MultipleActiveResultSets=True"
                );
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
