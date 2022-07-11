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
    /// Interaction logic for ListExpanding.xaml
    /// </summary>
    public partial class ListExpanding : Window
    {
        public bool listExpension = false;
        public ListExpanding()
        {
            InitializeComponent();
            listExpension = false;
        }

        private void listExpendingBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            listExpension = true;            
            ListExpandingWindow.Hide();
        }

        private void newListBtn_Click(object sender, RoutedEventArgs e)
        {
            ListExpandingWindow.Hide();
        }
    }
}
