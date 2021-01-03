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


        public MainWindow()
        {
            InitializeComponent();
;
            Thread t1 = new Thread(new ThreadStart(muoviMacchina));

            ImageSource im = new BitmapImage(uriMacchina);
            imgMacchina.Source = im;

            t1.Start();

            
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
