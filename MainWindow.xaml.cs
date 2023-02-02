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

namespace WpfApp2
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

        private void SzinKeveres() {
            rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(sliPiros.Value), Convert.ToByte(sliZold.Value), Convert.ToByte(sliKek.Value)));
        }

        private void sliPiros_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) { 
            SzinKeveres();
            labPiros.Content = Convert.ToByte(sliPiros.Value);
        }

        private void sliZold_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SzinKeveres();
            labZold.Content = Convert.ToByte(sliZold.Value);
        }

        private void sliKek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SzinKeveres();
            labKek.Content = Convert.ToByte(sliKek.Value);
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            string szinAdatok = $"{Convert.ToByte(sliPiros.Value)};{Convert.ToByte(sliZold.Value)};{Convert.ToByte(sliKek.Value)}";
            foreach (string item in lbSzinek.Items)
            {
                if (item == szinAdatok)
                {
                    MessageBox.Show("Ez a szín már létezik!");
                    return;
                }
            }
            lbSzinek.Items.Add(szinAdatok);
        }

        private void btnUrit_Click(object sender, RoutedEventArgs e)
        {
            lbSzinek.Items.Clear();
        }

        private void btnTorol_Click(object sender, RoutedEventArgs e)
        {
            if (lbSzinek.SelectedIndex >= 0)
            {
                lbSzinek.Items.RemoveAt(lbSzinek.SelectedIndex);
            }
            else {
                MessageBox.Show("Nincs kiválasztva semmi!");
            }
        }

        private void lbSzinek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbSzinek.SelectedIndex >= 0)
            { 
                string[] szinek = lbSzinek.Items[lbSzinek.SelectedIndex].ToString().Split(';');
                sliPiros.Value = Convert.ToByte(szinek[0]);
                sliZold.Value = Convert.ToByte(szinek[1]);
                sliKek.Value = Convert.ToByte(szinek[2]);
            }
        }
    }
}
