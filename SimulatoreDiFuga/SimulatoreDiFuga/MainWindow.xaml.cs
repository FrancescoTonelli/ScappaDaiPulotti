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
    public partial class MainWindow : Window //IMPORTANTE: i branch e il merge non sono stati usati perchè la programmazione del codice doveva essere lineare, programmare ogni "figura" in un branch suo avrebbe portato solo ad errori nel merge
    {
        readonly Uri uriTruffatore = new Uri("truffatore.png", UriKind.Relative);
        readonly Uri uriLadro = new Uri("ladro.png", UriKind.Relative);
        readonly Uri uriScooter = new Uri("scooter.png", UriKind.Relative);


        Thread t1;
        Thread t2;
        Thread t3;
        Thread t4;

        public MainWindow()
        {
            InitializeComponent();


            ImageSource immTruffatore = new BitmapImage(uriTruffatore);
            imgTruffatore.Source = immTruffatore;
            ImageSource immLadro = new BitmapImage(uriLadro);
            imgLadro.Source = immLadro;
            ImageSource immScooter = new BitmapImage(uriScooter);
            imgScooter.Source = immScooter;
        }

        public List<string> Arrivo;

        Random r = new Random();

        public void MuoviTruffatore()
        {
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
            Arrivo.Add("Il truffatore");
            
        }

        public void MuoviLadro()
        {
            int margineDaSpostare = 700;
            while (margineDaSpostare > 50)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(1, 1001)));
                margineDaSpostare -= 50;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    imgLadro.Margin = new Thickness(margineDaSpostare, 236, 0, 0);

                }));
            }
            Arrivo.Add("Il ladro");
        }

        public void MuoviScooter()
        {
            int margineDaSpostare = 700;
            while (margineDaSpostare > 50)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(1, 1001)));
                margineDaSpostare -= 50;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    imgScooter.Margin = new Thickness(margineDaSpostare, 205, 0, 0);

                }));
            }
            Arrivo.Add("Lo scooter fuori controllo");
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.IsEnabled = false;

            Arrivo = new List<string>();

            imgTruffatore.Margin = new Thickness(700, 270, 0, 0);

            imgLadro.Margin = new Thickness(700, 236, 0, 0);

            imgScooter.Margin = new Thickness(700, 205, 0, 0);

            t1 = new Thread(new ThreadStart(MuoviTruffatore));
            t2 = new Thread(new ThreadStart(MuoviLadro));
            t3 = new Thread(new ThreadStart(MuoviScooter));
            t4 = new Thread(new ThreadStart(ControlloERiattivazione));

            lbl1.Content = "";
            lbl2.Content = "";
            lbl3.Content = "";

            t1.Start();
            t2.Start();
            t3.Start();

            t4.Start();

            
        }

        private void ControlloERiattivazione()
        {
            while (Arrivo.Count != 3)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(1));
            }

            t1.Join();
            t2.Join();
            t3.Join();

            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                lbl1.Content = Arrivo[0] + " è scappato dalla polizia con grande vantaggio";
                lbl2.Content = Arrivo[1] + " è scappato dalla polizia";
                lbl3.Content = Arrivo[2] + " è scappato dalla polizia per un soffio";
                btnStart.IsEnabled = true;
            }));

        }
    }
}
