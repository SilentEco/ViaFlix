using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseConnection;
using MahApps.Metro.Controls;

namespace Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Movieslice();
            InitializeComponent();
            LoggedinLbl();
            HigestRated();
            ActionList();
            RomanceList();
            DramaList();
            ComedyList();
            ScifiList();
            
            

        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var x = Grid.GetColumn(sender as UIElement);
            var y = Grid.GetRow(sender as UIElement);

            int i = y * MovieGrid.ColumnDefinitions.Count + x;
            State.Pick = State.Movies[i];

            if (API.RegisterSale(State.User, State.Pick))
                MessageBox.Show("All is well and you can download your movie now.", "Sale Succeeded!", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("An error happened while buying the movie, please try again at a later time.", "Sale Failed!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        public void LoggedinLbl()
        {
            Namelbl.Content = $"Logged in as  \n{State.User.Username}";
        }

        public void ActionList()
        {
            Seeding seeding = new Seeding();

            
            State.Movies = API.GetMovieSlice(0, 30);
            for (int y = 1; y < 2; y++)
            {
                for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
                {
                    int i = y * MovieGrid.ColumnDefinitions.Count + x;
                    if (i < State.Movies.Count)
                    {
                        var movie = State.Movies[i];

                        var image = new Image() { };
                        image.Cursor = Cursors.Hand;
                        image.MouseUp += Image_MouseUp;
                        image.HorizontalAlignment = HorizontalAlignment.Center;
                        image.VerticalAlignment = VerticalAlignment.Center;
                        image.Source = new BitmapImage(new Uri(movie.ImageURL));
                        image.Height = 80;
                        image.Width = 120;

                        image.Margin = new Thickness(2, 2, 2, 2);

                        Action.Children.Add(image);

                        Grid.SetRow(image, y);
                        Grid.SetColumn(image, x);

                    }
                }
            }
        }
        public void HigestRated()
        {
            State.Movies = API.GetMovieSlice(0, 30);
            for (int y = 1; y < 2; y++)
            {
                for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
                {
                    int i = y * MovieGrid.ColumnDefinitions.Count + x;
                    if (i < State.Movies.Count)
                    {
                        var movie = State.Movies[i];

                        var image = new Image() { };
                        image.Cursor = Cursors.Hand;
                        image.MouseUp += Image_MouseUp;
                        image.HorizontalAlignment = HorizontalAlignment.Center;
                        image.VerticalAlignment = VerticalAlignment.Center;
                        image.Source = new BitmapImage(new Uri(movie.ImageURL));
                        image.Height = 80;
                        image.Width = 120;

                        image.Margin = new Thickness(2, 2, 2, 2);

                        MovieGrid.Children.Add(image);

                        Grid.SetRow(image, y);
                        Grid.SetColumn(image, x);

                    }
                }
            }
        }
        public void ComedyList()
        {
            State.Movies = API.GetMovieSlice(0, 30);
            for (int y = 1; y < 2; y++)
            {
                for (int x = 0; x < Comedy.ColumnDefinitions.Count; x++)
                {
                    int i = y * Comedy.ColumnDefinitions.Count + x;
                    if (i < State.Movies.Count)
                    {
                        var movie = State.Movies[i];

                        var image = new Image() { };
                        image.Cursor = Cursors.Hand;
                        image.MouseUp += Image_MouseUp;
                        image.HorizontalAlignment = HorizontalAlignment.Center;
                        image.VerticalAlignment = VerticalAlignment.Center;
                        image.Source = new BitmapImage(new Uri(movie.ImageURL));
                        image.Height = 80;
                        image.Width = 120;

                        image.Margin = new Thickness(2, 2, 2, 2);

                        Comedy.Children.Add(image);

                        Grid.SetRow(image, y);
                        Grid.SetColumn(image, x);

                    }
                }
            }
        }
        public void DramaList()
        {
            State.Movies = API.GetMovieSlice(0, 30);
            for (int y = 1; y < 2; y++)
            {
                for (int x = 0; x < Drama.ColumnDefinitions.Count; x++)
                {
                    int i = y * Drama.ColumnDefinitions.Count + x;
                    if (i < State.Movies.Count)
                    {
                        var movie = State.Movies[i];

                        var image = new Image() { };
                        image.Cursor = Cursors.Hand;
                        image.MouseUp += Image_MouseUp;
                        image.HorizontalAlignment = HorizontalAlignment.Center;
                        image.VerticalAlignment = VerticalAlignment.Center;
                        image.Source = new BitmapImage(new Uri(movie.ImageURL));
                        image.Height = 80;
                        image.Width = 120;

                        image.Margin = new Thickness(2, 2, 2, 2);
                        Drama.Children.Add(image);

                        Grid.SetRow(image, y);
                        Grid.SetColumn(image, x);

                    }
                }
            }
        }
        public void RomanceList() 
        {
            State.Movies = API.GetMovieSlice(0, 30);
            for (int y = 1; y < 2; y++)
            {
                for (int x = 0; x < Romance.ColumnDefinitions.Count; x++)
                {
                    int i = y * Romance.ColumnDefinitions.Count + x;
                    if (i < State.Movies.Count)
                    {
                        var movie = State.Movies[i];

                        var image = new Image() { };
                        image.Cursor = Cursors.Hand;
                        image.MouseUp += Image_MouseUp;
                        image.HorizontalAlignment = HorizontalAlignment.Center;
                        image.VerticalAlignment = VerticalAlignment.Center;
                        image.Source = new BitmapImage(new Uri(movie.ImageURL));
                        image.Height = 80;
                        image.Width = 120;

                        image.Margin = new Thickness(2, 2, 2, 2);

                        Romance.Children.Add(image);

                        Grid.SetRow(image, y);
                        Grid.SetColumn(image, x);

                    }
                }
            }
        }
        public void ScifiList() 
        {
            State.Movies = API.GetMovieSlice(0, 30);
            for (int y = 1; y < 2; y++)
            {
                for (int x = 0; x < Sci_fi.ColumnDefinitions.Count; x++)
                {
                    int i = y * Sci_fi.ColumnDefinitions.Count + x;
                    if (i < State.Movies.Count)
                    {
                        var movie = State.Movies[i];

                        var image = new Image() { };
                        image.Cursor = Cursors.Hand;
                        image.MouseUp += Image_MouseUp;
                        image.HorizontalAlignment = HorizontalAlignment.Center;
                        image.VerticalAlignment = VerticalAlignment.Center;
                        image.Source = new BitmapImage(new Uri(movie.ImageURL));
                        image.Height = 80;
                        image.Width = 120;

                        image.Margin = new Thickness(2, 2, 2, 2);

                        Sci_fi.Children.Add(image);

                        Grid.SetRow(image, y);
                        Grid.SetColumn(image, x);

                    }
                }
            }
        }

        public void Movieslice()
        {
            using (var ctx = new Context())
            {
                ctx.RemoveRange(ctx.Sales);
                ctx.RemoveRange(ctx.Movies);


                var movies = new List<Movie>();
                var lines = File.ReadAllLines(@"..\..\..\..\DatabaseConnection\SeedData\MovieGenre.csv");
                var genre_lines = File.ReadAllLines(@"..\..\..\..\DatabaseConnection\SeedData\MovieGenre.csv");
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
