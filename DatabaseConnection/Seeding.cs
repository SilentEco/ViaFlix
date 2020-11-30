using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection
{
    class Seeding
    {
        static void Main()
        {
            using (var ctx = new Context())
            {
                ctx.RemoveRange(ctx.Sales);
                ctx.RemoveRange(ctx.Movies);
                ctx.RemoveRange(ctx.Customers);



                var movies = new List<Movie>();
                var lines = File.ReadAllLines(@"..\..\..\SeedData\MovieGenre.csv");
                var genre_lines = File.ReadAllLines(@"..\..\..\SeedData\MovieGenre.csv");
                for (int i = 1; i < 200; i++)
                {
                    // imdbId,Imdb Link,Title,IMDB Score,Genre,Poster
                    var cells = lines[i].Split(',');
                    var url = cells[5].Trim('"');

                    // Hämta film genres
                    string[] genre_cells = genre_lines[i].Split(',');
                    string genre = genre_cells[4];

                    // Hoppa över alla icke-fungerande url:er
                    try { var test = new Uri(url); }
                    catch (Exception e) { continue; }

                    movies.Add(new Movie { Title = cells[2], ImageURL = url });
                }
                ctx.AddRange(movies);

                ctx.SaveChanges();

            }
        }
    }
}
