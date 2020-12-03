using System;
using System.Collections.Generic;
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
            InitializeComponent();
            LoggedinLbl();
            HigestRated();
            //ActionList();
            //RomanceList();
            //DramaList();
            //ComedyList();
            //ScifiList();



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
            //Namelbl.Content = $"Logged in as  \n{State.User.Username}";
        }
        public void HigestRated()
        {
            string[] genre_order = new string[] { "Action", "Romance", "Drama" };
            List<Genre> genres = API.GetGenres();
            for (int y = 0; y < genre_order.Length; y++)
            {
                Genre genre = genres.FirstOrDefault(g => g.Name == genre_order[y]);
                List<Movie> movies_by_genre = genre.Movies;

                for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
                {
                    int i = y * MovieGrid.ColumnDefinitions.Count + x;
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

                        Grid.SetRow(image, y);
                        Grid.SetColumn(image, x);

                    }
                }
            }
        }
    }
}