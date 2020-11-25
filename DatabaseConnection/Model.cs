using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConnection
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public virtual List<Rental> Sales { get; set; }
    }
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public virtual List<Rental> Sales { get; set; }
    }
    public class Rental
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
