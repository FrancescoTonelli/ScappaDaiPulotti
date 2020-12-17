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

namespace SimulatoreDiFuga
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Uri uriTruffatore = new Uri("truffatore.png", UriKind.Relative);
        readonly Uri uriLadro = new Uri("ladro.png", UriKind.Relative);
        readonly Uri uriScooter = new Uri("scooter.png", UriKind.Relative);
        public MainWindow()
        {
            InitializeComponent();

            Thread t1 = new Thread(new ThreadStart(MuoviTruffatore));
            Thread t2 = new Thread(new ThreadStart(MuoviLadro));
            Thread t3 = new Thread(new ThreadStart(MuoviScooter));

            ImageSource immTruffatore = new BitmapImage(uriTruffatore);
            imgTruffatore.Source = immTruffatore;
            ImageSource immLadro = new BitmapImage(uriLadro);
            imgLadro.Source = immLadro;
            ImageSource immScooter = new BitmapImage(uriScooter);
            imgScooter.Source = immScooter;

            t1.Start();
            t2.Start();
            t3.Start();
        }


        Random r = new Random();

        public void MuoviTruffatore()
        {
            int margineDaSpostare = 700;
            while (margineDaSpostare > 50)
            {
                margineDaSpostare -= 50;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    imgTruffatore.Margin = new Thickness(margineDaSpostare, 270, 0, 0);

                }));
                Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(1, 1001)));
            }
        }

        public void MuoviLadro()
        {
            int margineDaSpostare = 700;
            while (margineDaSpostare > 50)
            {
                margineDaSpostare -= 50;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    imgLadro.Margin = new Thickness(margineDaSpostare, 214, 0, 0);

                }));
                Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(1, 1001)));
            }
        }

        public void MuoviScooter()
        {
            int margineDaSpostare = 700;
            while (margineDaSpostare > 50)
            {
                margineDaSpostare -= 50;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    imgScooter.Margin = new Thickness(margineDaSpostare, 172, 0, 0);

                }));
                Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(1, 1001)));
            }
        }
    }
}
