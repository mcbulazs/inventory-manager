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
using System.Windows.Shapes;

namespace codefox_wpf_vesion_2
{
    /// <summary>
    /// Interaction logic for NewItem.xaml
    /// </summary>
    public partial class NewItem : Window
    {
        public string code;
        public string name;
        public string price;
        public List<Products> list = new List<Products>();
        public NewItem(string s, List<Products> l)
        {
            InitializeComponent();
            addCodeTB.Text = s;
            list = l;
        }

        private void addButn_Click(object sender, RoutedEventArgs e)
        {
            if (addCodeTB.Text == "" || addNameTB.Text == "" || addPriceTB.Text == "")
            {
                MessageBox.Show("Töltsd ki az összes mezőt!");
            }
            else if (!double.TryParse(addPriceTB.Text.Replace(",", "."), out double result))
                MessageBox.Show("Hibás árat adtál meg!");
            else
            {
                MainWindow mw = new MainWindow();
                if (mw.barcodeReader(addCodeTB.Text))
                {
                    if (result>=0)
                    {
                        if (list.Any(x => x.Barcode == addCodeTB.Text))
                            MessageBox.Show("Ilyen vonalkódú tétel már  van a rendszerben!");
                        else if (list.Any(x => x.Name == addNameTB.Text))
                            MessageBox.Show("ilyen nevű tétel már van a rendszerben!");
                        else
                        {
                            code = addCodeTB.Text;
                            name = addNameTB.Text;
                            price = addPriceTB.Text.Replace(",", ".");
                            this.Close();
                        }
                    }
                    else
                        MessageBox.Show("Nem adhatsz meg negtív árat!");
                }
                else
                    MessageBox.Show("Hibás vonalkód!");
            }
        }

        private void addCodeTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                addNameTB.Focus();
            }
        }

        private void addNameTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                addPriceTB.Focus();
            }
        }
    }
}
