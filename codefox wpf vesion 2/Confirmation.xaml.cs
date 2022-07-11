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
    /// Interaction logic for Confirmation.xaml
    /// </summary>
    public partial class Confirmation : Window
    {
        public Confirmation(string s)
        {
            InitializeComponent();
            if (s == "save")
                confirmationTB.Text = "Biztosan fel akarod tölteni a listát?";
            else if (s == "cancel")
                confirmationTB.Text = "Biztosan ki akarod törölni a listát?";
            else if (s == "purchaseEnd")
                confirmationTB.Text = "Biztosan befejezed a vásárlást?";
            else if(s=="purchaseCancel")
                confirmationTB.Text = "Biztosan törlöd a vásárlási Listát?";
            else
                confirmationTB.Text = "Biztosan törlöd a " + s + " vonalkódú tételt?";
        }
        public bool confirmationBool=false;
        private void yes_Click(object sender, RoutedEventArgs e)
        {
            confirmationBool = true;
            this.Hide();
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            confirmationBool = false;
            this.Hide();
        }
    }
}
