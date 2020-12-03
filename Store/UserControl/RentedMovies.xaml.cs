using DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Store.UserControl
{
    /// <summary>
    /// Interaction logic for RentedMovies.xaml
    /// </summary>
    public partial class RentedMovies
    {
        public RentedMovies()
        {
            InitializeComponent();
            MoviesRented();
            RentedMovieText();
            TextBoxtest();
        }

        public void MoviesRented()
        {

            State.Movies = API.GetMovieSlice(0, 30);

            for (int y = 0; y < RentedMovieGrid.RowDefinitions.Count; y++)
            {
                int i = RentedMovieGrid.RowDefinitions.Count + y;
                if (i < State.Movies.Count)
                {
                    var movie = State.Movies[i];

                    var image = new Image() { };
                    image.HorizontalAlignment = HorizontalAlignment.Center;
                    image.VerticalAlignment = VerticalAlignment.Center;
                    image.Source = new BitmapImage(new Uri(movie.ImageURL));
                    image.Height = 80;
                    image.Width = 120;

                    image.Margin = new Thickness(2, 2, 2, 2);

                    RentedMovieGrid.Children.Add(image);


                    Grid.SetRow(image, y);

                }
            }
        }

        public void TextBoxtest()
        {
            TestBox.Text = $"Hello {State.User.Movie.Title}";
        }

        public void RentedMovieText()
        {
            RentBox.Text = $"Hello {State.User.Name}, this is the movies you picked! ";
        }
    }
}
