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
        public MainWindow()
        {
            InitializeComponent();

            Thread t1 = new Thread(new ThreadStart(MuoviTruffatore));

            ImageSource immTruffatore = new BitmapImage(uriTruffatore);
            imgTruffatore.Source = immTruffatore;

            t1.Start();
        }

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
                Random r = new Random();
                Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(1, 1001)));
            }

        }
    }
}
