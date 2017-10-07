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
        static bool csokken = true;
        static int lenyomott = 0;
        static int alsohatar = 0;
        static int felsohatar = 10001;
        static int kozepso = (alsohatar + felsohatar) / 2;
        private void kisebb_Click(object sender, RoutedEventArgs e)
        {
            felsohatar = kozepso;
            kozepso = (alsohatar + felsohatar) / 2;
            talalat.Content = kozepso.ToString() + "?";
            lenyomott++;
            csokken = true;
        }

        private void nagyobb_Click(object sender, RoutedEventArgs e)
        {
            alsohatar = kozepso;
            kozepso = (alsohatar + felsohatar) / 2;
            talalat.Content = kozepso.ToString() + "?";
            lenyomott++;
            csokken = false;
        }

        private void egyenlő_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gratulálok! Nyertél! Lenyomott gomobok száma: "+lenyomott , "Nyertél!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void undo_Click(object sender, RoutedEventArgs e)
        {
            if (csokken)
            {
                kozepso = felsohatar - alsohatar;
                talalat.Content = kozepso.ToString() + "?";
                lenyomott--;
            }
            else
            {
                kozepso = felsohatar - alsohatar;
                talalat.Content = kozepso.ToString() + "?";
                lenyomott--;
            }
        }
    }
}
