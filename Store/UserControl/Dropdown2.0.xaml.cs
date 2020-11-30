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

namespace Store
{
    /// <summary>
    /// Interaction logic for Dropdown2.xaml
    /// </summary>
    public partial class Dropdown2 : UserControl
    {
        public Dropdown2()
        {
            InitializeComponent();
            customeDesign();
        }
        private void customeDesign()
        {
            GenrePanel.Visibility = Visibility.Hidden;
        }

        private void HidesubMenu()
        {
            if (GenrePanel.Visibility == Visibility.Visible)
                GenrePanel.Visibility = Visibility.Hidden;

        }

        private void showSubmenu(Panel SubMenu)
        {
            if (SubMenu.Visibility == Visibility.Hidden)
            {
                HidesubMenu();
                SubMenu.Visibility = Visibility.Visible;
            }
            else
                SubMenu.Visibility = Visibility.Hidden;
        }

        private void GenreButton_Click(object sender, RoutedEventArgs e)
        {
            showSubmenu(GenrePanel);
        }
    }
}
