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

namespace BerekeningCoupures
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private  double[] denominations = { 500.0, 200.0, 100.0, 50.0, 20.0, 10.0, 5.0, 2.0, 1.0, 0.50, 0.20, 0.10, 0.05, 0.02, 0.01 };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            resultTextBox.Clear();
            inputTextbox.Clear();
            inputTextbox.Focus();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (double.TryParse(inputTextbox.Text, out double bedrag) && bedrag > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Aantal");

               
                foreach (double coupure in denominations)
                {
                    int aantal = (int)(bedrag / coupure);
                    if (aantal > 0)
                    {
                        sb.AppendLine($"{aantal} stuk(s) van € {coupure:F2}");
                        bedrag -= aantal * coupure;
                        bedrag = Math.Round(bedrag, 2); 
                    }
                }

                resultTextBox.Text = sb.ToString();
            }
            else
            {
                MessageBox.Show("Voer een geldig bedrag in.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}