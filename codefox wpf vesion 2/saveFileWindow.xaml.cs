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
    /// Interaction logic for saveFileWindow.xaml
    /// </summary>
    public partial class saveFileWindow : Window
    {
        public saveFileWindow()
        {
            InitializeComponent();
        }
        public bool saveFileBool = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //nevvel
            saveFileBool = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            saveFileBool = false;
            this.Close();
        }
    }
}
