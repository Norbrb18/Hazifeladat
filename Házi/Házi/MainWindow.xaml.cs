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

namespace Házi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private int tipp = 5000;
        private void kisebb_Click(object sender, RoutedEventArgs e)
        {
            tipp -= tipp / 2;
            talalat.Content = tipp.ToString() + "?";
        }

        private void nagyobb_Click(object sender, RoutedEventArgs e)
        {
            tipp += tipp / 2;
            talalat.Content = tipp.ToString() + "?";
        }

        private void egyenlő_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gratulálok! Nyertél!", "Nyertél!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
}
