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
                ctx.RemoveRange(ctx.Genres);



                var movies = new List<Movie>();
                var genres = new List<Genre>();
                var lines = File.ReadAllLines(@"..\..\..\SeedData\MovieGenre.csv");
                for (int i = 1; i < 200; i++)
                {
                    // imdbId,Imdb Link,Title,IMDB Score,Genre,Poster
                    var cells = lines[i].Split(',');
                    var url = cells[5].Trim('"');

                    // Hämta film genres
                    string[] genre_cells = lines[i].Split(',');
                    string genre = genre_cells[4].Trim('"');
                    string[] genre_split = genre.Split('|');

                    var movie_genres = new List<Genre>();
                    foreach (var g in genre_split)
                    {
                        Genre genre_rec = new Genre() { Name=g };
                        genres.Add(genre_rec);
                        movie_genres.Add(genre_rec);
                    }

                    // Hoppa över alla icke-fungerande url:er
                    try { var test = new Uri(url); }
                    catch (Exception e) { continue; }

                    movies.Add(new Movie { Title = cells[2], ImageURL = url, Genres = movie_genres });
                }
                ctx.AddRange(movies);
                ctx.AddRange(genres);

                ctx.SaveChanges();

            }
        }
    }
}
