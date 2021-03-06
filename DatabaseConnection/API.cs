﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection
{
    public class API
    {
        static Context ctx;
        static API()
        {
            ctx = new Context();
        }


        //Kollar vilka genre som finns i filmlistan.
        public static List<Genre> GetGenres()
        {
            return ctx.Genres.ToList();
        }

        //Delar upp och hämtar filmerna.
        public static List<Movie> GetMovieSlice(int a, int b)
        {
            return ctx.Movies.OrderBy(m => m.Title).Skip(a).Take(b).ToList();
        }

        //Sätter användernamn 
        public static Customer GetCustomerByUsername(string Username)
        {
            return ctx.Customers.FirstOrDefault(c => c.Username == Username);
        }

        //Sätter lösenord.
        public static Customer GetCustomerByPassword(string password)
        {
            return ctx.Customers.FirstOrDefault(c => c.Password == password);
        }

        //Regristrerar ett "köp"
        public static bool RegisterSale(Customer customer, Movie movie)
        {
            try
            {
                // Här säger jag åt contextet att inte oroa sig över innehållet i dessa records.
                // Om jag inte gör detta så kommer den att försöka updatera databasens Id och cracha.
                ctx.Entry(customer).State = EntityState.Unchanged;
                ctx.Entry(movie).State = EntityState.Unchanged;

                ctx.Add(new Rental() { Date = DateTime.Now, Customer = customer, Movie = movie });
                return ctx.SaveChanges() == 1;
            }
            catch (DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException.Message);
                return false;
            }
        }
    }
}
