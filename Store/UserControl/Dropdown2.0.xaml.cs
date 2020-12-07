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
    /// Interaction logic for Dropdown2.xaml
    /// </summary>
    public partial class Dropdown2
    {
        private ActionPage ActionGenre;

        public Dropdown2()
        {
            InitializeComponent();
            customeDesign();
        }
      
        
       
        public void InitializeActionMenues(ActionPage ActionGenre)
        {
            this.ActionGenre = ActionGenre;
            ActionGenre.Visibility = Visibility.Hidden;
        }

// Gömmer och visar Genre panelen.
        private void customeDesign()
        {
            GenrePanel.Visibility = Visibility.Hidden;
        }

        private void HidesubMenu()
        {
            if (GenrePanel.Visibility == Visibility.Visible)
                GenrePanel.Visibility = Visibility.Hidden;

        }
        //-------------------------------------------------------------------------------
        // Gömmer och visar Submeny panelerna från genre panelen
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
        //-------------------------------------------------------------------------------
        //Knappen för Genre som ser till att den visar SubMeny
        private void GenreButton_Click(object sender, RoutedEventArgs e)
        {
            showSubmenu(GenrePanel);
        }


        //Knapp så dem gömmer och visar ActionGenre User control.
        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            if(ActionGenre.Visibility == Visibility.Hidden)
                ActionGenre.Visibility = Visibility.Visible;
            else
                ActionGenre.Visibility = Visibility.Hidden;
        }
    }
}
