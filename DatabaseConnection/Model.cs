using System;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection
{

    //Sätter records för Customer table
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public virtual List<Rental> Rentals { get; set; }
    }
    //Sätter records för Movie table
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public virtual List<Genre> Genres { get; set; }
        public virtual List<Rental> Rentals { get; set; }
    }
    //Sätter records för Genre table + en contraint för namn
    [Index(nameof(Name), IsUnique = true)]
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }
    //Sätter records för Rental table
    public class Rental
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
