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
            int buiziiiii;
        }
        
        Stack<string> seged = new Stack<string>();
        public string szinek(string param)
        { //asd
            string szin = "";
            while (Convert.ToInt32(param) > 0)
            {
                if (Convert.ToInt32(param) % 16 < 10)
                {
                    seged.Push(Convert.ToString(Convert.ToInt32(param) % 16));
                }
                else if (Convert.ToInt32(param) % 16 > 9)
                {
                    seged.Push(Convert.ToString(Convert.ToChar(55 + (Convert.ToInt32(param) % 16))));
                }

                param = Convert.ToString(Convert.ToInt32(param) / 16);
            }
            seged.Push("#");
            for (int i = seged.Count; i > 0; i--)
            {
                szin += seged.Pop();
                
            }
            return szin;
        }
        static Stack<bool> mentes = new Stack<bool>();
        static int lenyomott = 0;
        static double alsohatar = 0;
        static double felsohatar = 10000;
        static double kozepso = (alsohatar + felsohatar) / 2;
        private void kisebb_Click(object sender, RoutedEventArgs e)
        {
            felsohatar = kozepso;
            kozepso = (alsohatar + felsohatar) / 2;
            talalat.Text = Math.Round(kozepso,MidpointRounding.ToEven).ToString();
            lenyomott++;
            mentes.Push(true);
            try
            {
                this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(szinek(talalat.Text)));
            }
            catch (Exception)
            {

                Random vel = new Random();
                this.Background = new SolidColorBrush(Color.FromRgb((byte)vel.Next(0, 255), (byte)vel.Next(0, 255), (byte)vel.Next(0, 255)));
            }
            
         
            undo.IsEnabled = true;
        }

        private void nagyobb_Click(object sender, RoutedEventArgs e)
        {
            alsohatar = kozepso;
            kozepso = (alsohatar + felsohatar) / 2;
            talalat.Text = Math.Round(kozepso,0,MidpointRounding.ToEven).ToString();
            lenyomott++;
            mentes.Push(false);
            try
            {
               this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(szinek(talalat.Text)));
            }
            catch (Exception)
            {

                Random vel = new Random();
                this.Background = new SolidColorBrush(Color.FromRgb((byte)vel.Next(0, 255), (byte)vel.Next(0, 255), (byte)vel.Next(0, 255)));
            }
            
            undo.IsEnabled = true;
        }

        private void egyenlő_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gratulálok! Nyertél! Lenyomott gomobok száma: "+lenyomott , "Nyertél!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void undo_Click(object sender, RoutedEventArgs e)
        {
            if (mentes.Peek())
            {
                kozepso = felsohatar;
                felsohatar = kozepso*2 - alsohatar ;
                talalat.Text = Math.Round(kozepso).ToString();
                lenyomott--;
                mentes.Pop();
               
            }
            else if (!mentes.Peek())
            {
                kozepso = alsohatar;
                alsohatar = alsohatar*2-felsohatar;
                talalat.Text = Math.Round(kozepso,0,MidpointRounding.ToEven).ToString();
                lenyomott--;
                mentes.Pop();
                
            }

            if (Math.Round(kozepso) == 5000)
            {
                undo.IsEnabled = false;
            }
            try
            {
                this.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(szinek(talalat.Text)));
            }
            catch (Exception)
            {
                Random vel = new Random();
                this.Background = new SolidColorBrush(Color.FromRgb((byte)vel.Next(0, 255), (byte)vel.Next(0, 255), (byte)vel.Next(0, 255)));
            }
        }
    }
}
