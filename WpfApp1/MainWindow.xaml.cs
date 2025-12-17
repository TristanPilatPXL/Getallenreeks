using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfApp1
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

        private void toonLijst(object sender, RoutedEventArgs e)
        {
            string Getal;
            Getal = getal.Text;

            if (int.TryParse(Getal, out int parsedValue))
            {
                if (parsedValue < 1 || parsedValue > 100)
                {
                    MessageBox.Show($"Geef een geheel getal in tussen 1 en 100", "Ongeldige waarde", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


                // Bereken hoeveel lege plekken nodig zijn op de eerste rij
                int eersteRijAantal = parsedValue % 10;
                if (eersteRijAantal == 0) eersteRijAantal = 10;

                int legeKolommen = 9 - eersteRijAantal;

                // Voeg lege tabs toe aan het begin
                for (int i = 0; i < legeKolommen; i++)
                {
                    resultaat.Text += "\t";
                }

                int kolom = legeKolommen;

                for (int i = parsedValue; i >= 1; i--)
                {
                    resultaat.Text += $"{i}\t";
                    kolom++;

                    // Na elke 10 kolommen een nieuwe regel
                    if (kolom == 10)
                    {
                        resultaat.Text += "\n";
                        kolom = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show($"Geef een geheel getal in tussen 1 en 100", "Ongeldige waarde", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void wissen(object sender, RoutedEventArgs e)
        {
            resultaat.Text = "";  // Reset eerst de tekst
            getal.Text = "";     // Reset ook het invoerveld

        }

        private void aflsuiten(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}