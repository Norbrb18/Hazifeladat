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
using System.IO;

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
            beolvas();
        }
        private void beolvas()      //Csak a beolvasás semmi extra de mindent be kommentelek hogy átlásd
        {
            using (StreamReader sr = new StreamReader("mentes.txt"))
                while (!sr.EndOfStream)
                {
                    string asd = sr.ReadLine();
                    mentesek.Add(Convert.ToInt32(asd));
                }
        }
        private void kiir()     //Sima kiiratás
        {
            using (StreamWriter sw = new StreamWriter("mentes.txt"))
                for (int i = 0; i < mentesek.LongCount(); i++)
                {
                    sw.WriteLine(mentesek[i]);
                }
        }
        private double AI()                 //Itt jön a tricky rész. A mentett számokból és a középből átlagot vonok majd vissza köldöm ezt. 
        {                               //Elvileg így egy tartományt nem felezni fogok hanem egy kicsivel mindig fölé vagy alá lőni átlag szerint. 
            int db = 1;
            double atlag = 0;
            for (int i = 0; i < mentesek.LongCount(); i++)
            {
                if (mentesek[i] > alsohatar && mentesek[i] < felsohatar)
                {
                    atlag += mentesek[i];           
                    db++;
                }
            }
            atlag += kozepso;
            atlag = atlag / db;
            return atlag;
        }
        private double kereses(bool melyik)         //A te kereséses csak megírtam függvényként mert még kelleni fog
        {
            if (!melyik)
            {
                felsohatar = kozepso;
                lenyomott++;
                csokken.Push(true);
                undo.IsEnabled = true;
                double seged = AI();                //Itt akadtam el de reggel folytatom :D az undóra azt találtam ki hogy a számokat is eltárolom egy veremben és csak vissza hívom de nem akar működni...
                return AI();                        //És az AI függvény se jó. Sokszor elbassza de már geci álmos vagyok holnap újra gondolom.

            }
            else 
            {
                alsohatar = kozepso;
                lenyomott++;
                csokken.Push(false);
                undo.IsEnabled = true;
                return AI();
            }
        }
        static List<int> mentesek = new List<int>();
        //Át írtam veremre mert így nem kell előre lefoglalni az 1000 helyet a bool tömbnek :) Ezt a vermet kb erre találták ki :D
        static Stack<bool> csokken = new Stack<bool>();
        static Stack<double> tarol = new Stack<double>();
        static int lenyomott = 0;
        static double alsohatar = 0;
        static double felsohatar = 10000;
        static double kozepso = (alsohatar + felsohatar) / 2;
        private void kisebb_Click(object sender, RoutedEventArgs e)
        {
            talalat.Content = Math.Round(kereses(false), MidpointRounding.ToEven).ToString() + "?";
            csakteszt.Content = "felso: " + felsohatar + "   also: " + alsohatar;
        }

        private void nagyobb_Click(object sender, RoutedEventArgs e)
        {
            talalat.Content = Math.Round(kereses(true), 0, MidpointRounding.ToEven).ToString() + "?";
            csakteszt.Content = "felso: " + felsohatar + "   also: " + alsohatar;
        }

        private void egyenlő_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gratulálok! Nyertél! Lenyomott gomobok száma: "+lenyomott , "Nyertél!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            mentesek.Add((int)Math.Round(kozepso, 0, MidpointRounding.ToEven));
            kiir();
        }

        private void undo_Click(object sender, RoutedEventArgs e)
        {
            if (csokken.Peek())
            {
                kozepso = felsohatar;
                tarol.Pop();
                talalat.Content = Math.Round(kozepso).ToString() + "?";
                lenyomott--;
                csokken.Pop();
            }
            else if (!csokken.Peek())
            {
                kozepso = alsohatar;
                tarol.Pop();
                talalat.Content = Math.Round(kozepso,0,MidpointRounding.ToEven).ToString() + "?";
                lenyomott--;
                csokken.Pop();
            }

            if (Math.Round(kozepso) == 5000)
            {
                undo.IsEnabled = false;
            }
        }
    }
}
