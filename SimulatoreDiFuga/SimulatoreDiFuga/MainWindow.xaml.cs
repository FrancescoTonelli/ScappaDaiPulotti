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


        Thread t1;
        Thread t2;
        Thread t3;

        public MainWindow()
        {
            InitializeComponent();

            t1 = new Thread(new ThreadStart(MuoviTruffatore));
            t2 = new Thread(new ThreadStart(MuoviLadro));
            t3 = new Thread(new ThreadStart(MuoviScooter));

            ImageSource immTruffatore = new BitmapImage(uriTruffatore);
            imgTruffatore.Source = immTruffatore;
            ImageSource immLadro = new BitmapImage(uriLadro);
            imgLadro.Source = immLadro;
            ImageSource immScooter = new BitmapImage(uriScooter);
            imgScooter.Source = immScooter;
        }

        public bool TruffatoreArrivato;
        public bool LadroArrivato;
        public bool ScooterArrivato;

        Random r = new Random();

        public void MuoviTruffatore()
        {
            TruffatoreArrivato = false;
            int margineDaSpostare = 700;
            while (margineDaSpostare > 50)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(1, 1001)));
                margineDaSpostare -= 50;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    imgTruffatore.Margin = new Thickness(margineDaSpostare, 270, 0, 0);

                }));
            }
            TruffatoreArrivato = true;

            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (LadroArrivato == false && ScooterArrivato == false)
                {
                    lbl1.Content = "Il truffatore è scappato dalla polizia con grande vantaggio";
                }
                else if (LadroArrivato == true && ScooterArrivato == true)
                {
                    lbl3.Content = "Il truffatore è scappato dalla polizia per un soffio";
                }
                else if (LadroArrivato == true || ScooterArrivato == true)
                {
                    lbl2.Content = "Il truffatore è scappato dalla polizia";
                }

            }));
            
        }

        public void MuoviLadro()
        {
            LadroArrivato = false;
            int margineDaSpostare = 700;
            while (margineDaSpostare > 50)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(1, 1001)));
                margineDaSpostare -= 50;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    imgLadro.Margin = new Thickness(margineDaSpostare, 214, 0, 0);

                }));
            }
            LadroArrivato = true;
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (TruffatoreArrivato == false && ScooterArrivato == false)
                {
                    lbl1.Content = "Il ladro è scappato dalla polizia con grande vantaggio";
                }
                else if (TruffatoreArrivato == true && ScooterArrivato == true)
                {
                    lbl3.Content = "Il ladro è scappato dalla polizia per un soffio";
                }
                else if (TruffatoreArrivato == true || ScooterArrivato == true)
                {
                    lbl2.Content = "Il ladro è scappato dalla polizia";
                }

            }));
        }

        public void MuoviScooter()
        {
            ScooterArrivato = false;
            int margineDaSpostare = 700;
            while (margineDaSpostare > 50)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(1, 1001)));
                margineDaSpostare -= 50;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    imgScooter.Margin = new Thickness(margineDaSpostare, 172, 0, 0);

                }));
            }
            ScooterArrivato = true;

            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (TruffatoreArrivato == false && LadroArrivato == false)
                {
                    lbl1.Content = "Lo scooter fuori controllo è scappato dalla polizia con grande vantaggio";
                }
                else if (TruffatoreArrivato == true && LadroArrivato == true)
                {
                    lbl3.Content = "Lo scooter fuori controllo è scappato dalla polizia per un soffio";
                }
                else if (TruffatoreArrivato == true || LadroArrivato == true)
                {
                    lbl2.Content = "Lo scooter fuori controllo è scappato dalla polizia";
                }

            }));
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = false;
            t1.Start();
            t2.Start();
            t3.Start();
        }
    }
}
