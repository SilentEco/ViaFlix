using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Store
{
    /// <summary>
    /// Interaction logic for DropdownMenu.xaml
    /// </summary>
    public partial class DropdownMenu : UserControl
    {
        public DropdownMenu()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = this.FindResource("Storyboard1") as Storyboard;
            Storyboard.SetTarget(sb, this.listBox);
            sb.Begin();

            
        }
    }
}
