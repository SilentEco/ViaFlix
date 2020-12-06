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
using Store.UserControl;

namespace Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Dropdown2.InitializeActionMenues(ActionPageTest);
            Namelabel();
            HigestRated();

        }


        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var x = Grid.GetColumn(sender as UIElement);

            int i = MovieGrid.ColumnDefinitions.Count + x;
            State.Pick = State.Movies[i];

            if (API.RegisterSale(State.User, State.Pick))
            {
                MessageBox.Show($"You Picked the movie {State.Pick.Title}.", "Sale Succeeded!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
                MessageBox.Show("An error happened while buying the movie, please try again at a later time.", "Sale Failed!", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            RentedMovies.RefreshRented.MoviesRented();
        }

        public void Namelabel()
        {
            UpperNamelbl.Content = "Hello and welcome";
            LowerNamelbl.Content = $"{State.User.Name}";
        }
        public void HigestRated()
        {
            // Vilken ordning ska genres visas
            string[] genre_order = new string[] {
                                                "Adventure",
                                                "Comedy",
                                                "Action",
                                                "Family",
                                                "Comedy",
                                                "Romance",
                                                "Drama",
                                                "Crime",
                                                "History",
                                                "Sci-Fi",
                                                "Biography",
                                                "Horror",
                                                "Thriller",
                                                "War",
                                                "Mystery"};

            // Hämta genres ur genrelistan
            List<Genre> genres = API.GetGenres();

            //      Rad           Antalet Genres
            //       v          v                v
            for (int y = 0; y < genre_order.Length; y++)
            {
                Genre genre = genres.FirstOrDefault(g => g.Name == genre_order[y]);


                List<Movie> movies_by_genre = genre.Movies;

                for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
                {
                    int i = x;
                    if (i < movies_by_genre.Count)
                    {
                        var movie = movies_by_genre[i];

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


                        Grid.SetColumn(image, x);

                    }
                }

            }
        }


        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            if (Rentedmovies.Visibility == Visibility.Visible)
                Rentedmovies.Visibility = Visibility.Hidden;

            if (ActionPageTest.Visibility == Visibility.Visible)
                ActionPageTest.Visibility = Visibility.Hidden;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You've succesfully logged out", "Logged out");
            var LogOut = new LoginWindow();
            LogOut.Show();
            this.Close();

        }

        private void RentedMoviebtn_Click(object sender, RoutedEventArgs e)
        {

            if (Rentedmovies.Visibility == Visibility.Hidden)

                Rentedmovies.Visibility = Visibility.Visible;
            else
                Rentedmovies.Visibility = Visibility.Hidden;

        }
    }
}