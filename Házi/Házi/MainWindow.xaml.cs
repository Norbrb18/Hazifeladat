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
        static bool[] csokken = new bool[1000];
        static int lenyomott = -1;
        static double alsohatar = 0;
        static double felsohatar = 10000;
        static double kozepso = (alsohatar + felsohatar) / 2;
        private void kisebb_Click(object sender, RoutedEventArgs e)
        {
            felsohatar = kozepso;
            kozepso = (alsohatar + felsohatar) / 2;
            talalat.Content = Math.Round(kozepso,MidpointRounding.ToEven).ToString() + "?";

            lenyomott++;
            csokken[lenyomott] = true;
            

            undo.IsEnabled = true;
        }

        private void nagyobb_Click(object sender, RoutedEventArgs e)
        {
            alsohatar = kozepso;
            kozepso = (alsohatar + felsohatar) / 2;
            talalat.Content = Math.Round(kozepso,0,MidpointRounding.ToEven).ToString() + "?";

            lenyomott++;
            csokken[lenyomott] = false;
            

            undo.IsEnabled = true;
        }

        private void egyenlő_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gratulálok! Nyertél! Lenyomott gomobok száma: "+lenyomott , "Nyertél!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void undo_Click(object sender, RoutedEventArgs e)
        {
            if (csokken[lenyomott])
            {
                kozepso = felsohatar;
                felsohatar = kozepso*2 - alsohatar ;
                talalat.Content = Math.Round(kozepso).ToString() + "?";
                lenyomott--;
            }
            else if (!csokken[lenyomott])
            {
                kozepso = alsohatar;
                alsohatar = alsohatar*2-felsohatar;
                talalat.Content = Math.Round(kozepso,0,MidpointRounding.ToEven).ToString() + "?";
                lenyomott--;
            }

            if (Math.Round(kozepso) == 5000)
            {
                undo.IsEnabled = false;
            }
        }
    }
}
