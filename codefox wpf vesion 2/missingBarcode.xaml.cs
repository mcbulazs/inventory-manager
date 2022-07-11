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
    /// Interaction logic for missingBarcode.xaml
    /// </summary>
    public partial class missingBarcode : Window
    {
        public missingBarcode()
        {
            InitializeComponent();
        }
        public bool newItem=false;

        private void productAddBtn_Click(object sender, RoutedEventArgs e)
        {
            newItem = true;
            this.Hide();
        }

        private void Nobtn_Click(object sender, RoutedEventArgs e)
        {
            newItem = false;
            this.Hide();
        }
    }
}
