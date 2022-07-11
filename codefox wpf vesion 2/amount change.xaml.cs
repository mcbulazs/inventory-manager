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
    /// Interaction logic for amount_change.xaml
    /// </summary>
    public partial class amount_change : Window
    {
        public amount_change( int s)
        {
            InitializeComponent();
            amountTB.Text = s.ToString();
            amountTB.Focus();
            amountTB.Select(0,amountTB.Text.Length);
        }
        public int changedAmount=0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(amountTB.Text, out int result))
            {
                if (result > 1)
                { 
                    changedAmount = result;
                    this.Hide();
                }

                else
                    MessageBox.Show("Nem adhatsz meg egynél kevesebb mennyiséget!");
            }
            else
                MessageBox.Show("Érvényes számot adj meg!");
        }
    }
}
