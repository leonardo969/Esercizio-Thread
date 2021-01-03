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
using System.Threading;

namespace Esercizio_Thread
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Uri uriMacchina = new Uri("Maccchina.png", UriKind.Relative);
        int posMacchina;

        readonly Uri uriAereo = new Uri("Aereo.png", UriKind.Relative);
        int posAereo;

        readonly Uri uriMessi = new Uri("Messi.png", UriKind.Relative);
        int posMessi;

        public MainWindow()
        {
            InitializeComponent();

            Thread t1 = new Thread(new ThreadStart(muoviMacchina));

            ImageSource im = new BitmapImage(uriMacchina);
            imgMacchina.Source = im;

            t1.Start();

            Thread t2 = new Thread(new ThreadStart(muoviAereo));

            ImageSource im2 = new BitmapImage(uriAereo);
            imgAereo.Source = im2;

            t2.Start();

            Thread t3 = new Thread(new ThreadStart(muoviMessi));

            ImageSource im3 = new BitmapImage(uriMessi);
            imgMessi.Source = im3;

            t3.Start();

            lbl.Content = "I concorrenti sono arrivati a parimerito";
        }

        public void muoviMacchina()
        {
            while (posMacchina < 685)
            {
                posMacchina += 30;

                Thread.Sleep(TimeSpan.FromMilliseconds(500));

                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    imgMacchina.Margin = new Thickness(posMacchina, 63, 0, 0);
                }));
            }
        }

        
    }
}
