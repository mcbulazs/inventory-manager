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
using System.IO;
using Microsoft.Win32;
using System.Globalization;
using System.Threading;

namespace codefox_wpf_vesion_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Products> productList = new List<Products>();
        public List<supply> supplyList = new List<supply>();
        public List<Products> salesList = new List<Products>();
        public string globalBarcode;
        bool selectionChange;
        double requiredMoney=0;
        public bool barcodeReader(string barcode)
        {
            if (barcode.Length!=13)
                return false;
            int[] numbers = new int[13];
            int checkDigit = 0;
            for (int i = 0; i < barcode.Length; i++)
            {
                numbers[i] = int.Parse(barcode[i].ToString());
            }
            int oddPosition=0;
            int evenPosition=0;
            for (int i = 0; i < 12; i++)
            {
                if ((i + 1) % 2 == 0)
                    evenPosition += numbers[i];
                else
                    oddPosition += numbers[i];
            }
            evenPosition *= 3;
            int sum = evenPosition + oddPosition;
            int unitdigit = int.Parse(sum.ToString()[sum.ToString().Length-1].ToString());
            if (unitdigit==0)
                checkDigit = 0;
            else
                checkDigit = 10 - unitdigit;
            if (numbers[12] == checkDigit)
                return true;
            else
                return false;

        }
        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState!=WindowState.Maximized)
            {

                productsTab.Width = window.Width / 3 - 7;
                poolTab.Width = window.Width / 3 - 7;
                salesTab.Width = window.Width / 3 - 7;

                //tab1
                //productsListDatagrid
                productslistDatagrid.Height =window.Height+100;
                //openfilebtn
                openFileVB.Width = window.Width / 3;
                openFileVB.Margin = new Thickness(window.Width / 12,0, 0,0 );
                //savefilebtn
                saveFileVB.Width = window.Width / 3;
                saveFileVB.Margin = new Thickness(window.Width / 12, window.Height/8, 0, 0);
                //newProductBtn
                newRowVB.Width = window.Width / 3;
                newRowVB.Margin = new Thickness(window.Width / 12, window.Height / 8 * 2, 0, 0);
                //listModifyBtn
                listModifyVB.Width = window.Width / 3;
                listModifyVB.Margin = new Thickness(window.Width / 12, window.Height / 8*3, 0, 0);
                //selectedRowProperties
                selectedItemVb.Width = window.Width / 3;
                selectedItemVb.Margin = new Thickness(window.Width / 12, window.Height / 8 * 4, 0, 0);



                //tab2
                //supplyDatagrid
                //supplyDatagridVB.Width = window.Width / 2;
                supplyDatagrid.Height = window.Height + 100;
                
                //supplyAdd    
                supplyAddVB.Width = window.Width / 3;
                supplyAddVB.Margin = new Thickness(0, window.Height / 8, window.Width/ 12, 0);
                supplyAddBtn.Width = supplyAddVB.Width / 9;
                supplyBarcodeTB.Width = supplyAddVB.Width / 3 * 2;
                supplyAmountTB.Width = supplyAddVB.Width / 9*2;
                //supplyModify
                supplyModifyVB.Width = window.Width / 8*3;
                supplyModifyVB.Margin = new Thickness(0, window.Height / 8 * 2, window.Width / 12, 0);
                //supplySave
                supplySaveVB.Width = window.Width / 8 * 3;
                supplySaveVB.Margin = new Thickness(0, window.Height / 8 * 5, window.Width / 12, 0);


                //tab3
                //salesDatagrid
                //salesDatagridVB.Width = window.Width / 2;
                salesDatagrid.Height = window.Height + 100;

                //salesAdd    
                salesAddVB.Width = window.Width / 3;
                salesAddVB.Margin = new Thickness(0, window.Height / 8, window.Width / 12, 0);
                salesAddBtn.Width = salesAddVB.Width / 9;
                salesBarcodeTB.Width = salesAddVB.Width / 3 * 2;
                salesAmountTB.Width = salesAddVB.Width / 9 * 2;
                //salesModify
                salesModifyVB.Width = window.Width / 8 * 3;
                salesModifyVB.Margin = new Thickness(0, window.Height / 8 * 2, window.Width / 12, 0);
                //price
                priceVB.Width = window.Width / 3;
                priceVB.Height = window.Height / 6;
                priceVB.Margin = new Thickness(0, window.Height / 8 , window.Width / 12, 0);

                //salesSave
                salesSaveVB.Width = window.Width / 8 * 3;
                salesSaveVB.Margin = new Thickness(0, window.Height / 8 * 5, window.Width / 12, 0);
            }
        }
        private void window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState==WindowState.Maximized)
            {
                productsTab.Width = SystemParameters.PrimaryScreenWidth / 3 -2;
                poolTab.Width = SystemParameters.PrimaryScreenWidth / 3 -2;
                salesTab.Width = SystemParameters.PrimaryScreenWidth / 3-2;              
                //openfilebtn
                openFileVB.Width = SystemParameters.PrimaryScreenWidth / 3;
                openFileVB.Margin = new Thickness(SystemParameters.PrimaryScreenWidth/ 12, 0, 0, 0);
                //savefilebtn
                saveFileVB.Width = SystemParameters.PrimaryScreenWidth / 3;
                saveFileVB.Margin = new Thickness(SystemParameters.PrimaryScreenWidth / 12, SystemParameters.PrimaryScreenHeight / 10, 0, 0);
                //newProductBtn
                newRowVB.Width = SystemParameters.PrimaryScreenWidth / 3;
                newRowVB.Margin = new Thickness(SystemParameters.PrimaryScreenWidth/ 12, SystemParameters.PrimaryScreenHeight / 10 * 2, 0, 0);
                //listModifyBtn
                listModifyVB.Width = SystemParameters.PrimaryScreenWidth / 3;
                listModifyVB.Margin = new Thickness(SystemParameters.PrimaryScreenWidth/ 12, SystemParameters.PrimaryScreenHeight / 10 * 3, 0, 0);
                //selectedRowProperties
                selectedItemVb.Width = SystemParameters.PrimaryScreenWidth / 3;
                selectedItemVb.Margin = new Thickness(SystemParameters.PrimaryScreenWidth / 12, SystemParameters.PrimaryScreenHeight / 10 * 4, 0, 0);

                //2
                //supplyDatagrid
                supplyDatagridVB.Width = SystemParameters.PrimaryScreenWidth / 2;
            
                //supplyAdd
                supplyAddVB.Width = SystemParameters.PrimaryScreenWidth / 3;
                supplyAddVB.Height = SystemParameters.PrimaryScreenHeight / 10;
                supplyAddVB.Margin = new Thickness(0, SystemParameters.PrimaryScreenHeight / 8, SystemParameters.PrimaryScreenWidth / 12, 0);
                supplyBarcodeTB.Width = supplyAddVB.Width / 3 * 2;
                supplyAmountTB.Width = supplyAddVB.Width / 9 * 2;
                supplyAddBtn.Width = supplyAddVB.Width / 9;
                //supplyModify
                supplyModifyVB.Width = SystemParameters.PrimaryScreenWidth / 8 * 3;
                supplyModifyVB.Margin = new Thickness(0, SystemParameters.PrimaryScreenHeight / 8 * 2, SystemParameters.PrimaryScreenWidth / 12, 0);
                //supplySave
                supplySaveVB.Width = SystemParameters.PrimaryScreenWidth / 8 * 3;
                supplySaveVB.Margin = new Thickness(0, SystemParameters.PrimaryScreenHeight / 8 * 5, SystemParameters.PrimaryScreenWidth / 12, 0);




                //3
                //salesDatagrid
                salesDatagridVB.Width = SystemParameters.PrimaryScreenWidth / 2;

                //salesAdd
                salesAddVB.Width = SystemParameters.PrimaryScreenWidth / 3;
                salesAddVB.Height = SystemParameters.PrimaryScreenHeight / 10;
                salesAddVB.Margin = new Thickness(0, SystemParameters.PrimaryScreenHeight / 8, SystemParameters.PrimaryScreenWidth / 12, 0);
                salesBarcodeTB.Width = salesAddVB.Width / 3 * 2;
                salesAmountTB.Width = salesAddVB.Width / 9 * 2;
                salesAddBtn.Width = salesAddVB.Width / 9;
                //salesModify
                salesModifyVB.Width = SystemParameters.PrimaryScreenWidth / 8 * 3;
                salesModifyVB.Margin = new Thickness(0, SystemParameters.PrimaryScreenHeight / 8 * 2, SystemParameters.PrimaryScreenWidth / 12, 0);

                //price
                priceVB.Width = SystemParameters.PrimaryScreenWidth / 3;
                priceVB.Height = SystemParameters.PrimaryScreenHeight / 6;
                priceVB.Margin = new Thickness(0, SystemParameters.PrimaryScreenHeight / 8 , SystemParameters.PrimaryScreenWidth / 12, 0);

                //salesSave
                salesSaveVB.Width = SystemParameters.PrimaryScreenWidth / 8 * 3;
                salesSaveVB.Margin = new Thickness(0, SystemParameters.PrimaryScreenHeight / 8 * 5, SystemParameters.PrimaryScreenWidth / 12, 0);
            }
            
        }


        public MainWindow()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            InitializeComponent();
            productslistDatagrid.ItemsSource = productList;
            supplyDatagrid.ItemsSource = supplyList;
            salesDatagrid.ItemsSource = salesList;
        }
        private void openFileBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "CSV|*.csv|Text|*.txt";
                opf.ShowDialog();
                bool listExpandingBool = true;
                if (productList.Count != 0)
                {
                    ListExpanding le = new ListExpanding();
                    le.Owner = this;
                    le.ShowDialog();
                    listExpandingBool = le.listExpension;
                }
                if (listExpandingBool == false)
                {
                    productList.Clear();
                }
                productslistDatagrid.Items.Refresh();
                listExpandingBool = false;
                StreamReader sr = new StreamReader(opf.FileName);
                try
                {
                    if (!char.IsDigit(sr.ReadLine()[0]))
                    {
                        while (!sr.EndOfStream)
                        {
                            listFill(sr.ReadLine());
                        }
                        sr.Close();
                    }
                    else
                    {
                        foreach (var item in File.ReadAllLines(opf.FileName))
                        {
                            listFill(item);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hibás fájl");
                }
                productslistDatagrid.Items.Refresh();
            }
            catch (Exception) { }
        }

        private void listFill(string s)
        {           
            if (productList.Any(x=>x.Barcode == new Products(s).Barcode))
                productList.Where(x => x.Barcode == new Products(s).Barcode).First().Amount += new Products(s).Amount;
            else
                productList.Add(new Products(s));
            productslistDatagrid.Items.Refresh();
        }

        private void saveFileBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (productList.Count != 0)
                {
                    saveFileWindow sfw = new saveFileWindow();
                    sfw.Owner = this;
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "CSV|*.csv|Text|*.txt";
                    sfd.ShowDialog();
                    StreamWriter sw = new StreamWriter(sfd.FileName);
                    sfw.ShowDialog();
                    if (sfw.saveFileBool)
                    {
                        sw.WriteLine("Vonalkód;Megnevezés;Raktárkészlet;Egységár");
                    }
                    foreach (var item in productList)
                    {
                        sw.WriteLine(item.Barcode + ";" + item.Name + ";" + item.Amount + ";" + item.Price);
                    }
                    sw.Close();
                }
            }
            catch (Exception) { }
        }
        private void productslistDatagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItemFill();
        }

        private void selectedItemFill()
        {
            if (selectionChange)
            {
                selectedItemCodeTB.Text = productList[productslistDatagrid.SelectedIndex].Barcode;
                selectedItemNameTB.Text = productList[productslistDatagrid.SelectedIndex].Name;
                selectedItemPriceTB.Text = productList[productslistDatagrid.SelectedIndex].Price.ToString();
            }
        }

        private void listModifyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (productslistDatagrid.SelectedIndex>-1&& productslistDatagrid.SelectedIndex<productList.Count)
            {
                selectionChange = true;
                selectedItemFill();
                selectedItemVb.Visibility = Visibility.Visible;
            }
        }

        private void saveModifyBtn_Click(object sender, RoutedEventArgs e)
        {
            saveRowModification();
        }

        private void saveRowModification()
        {
            if (!barcodeReader(selectedItemCodeTB.Text))
                MessageBox.Show("Hibás vonalkódot adtál meg!");
            else if (productList.Any(x => x.Barcode == selectedItemCodeTB.Text) && productList[productslistDatagrid.SelectedIndex].Barcode!= selectedItemCodeTB.Text)
                MessageBox.Show("Ez a vonalkód már van a rendszerben");
            else if (!double.TryParse(selectedItemPriceTB.Text.Replace(",", "."), out double result)) MessageBox.Show("Hibás árat adtál meg!");
            else
            {
                productList[productslistDatagrid.SelectedIndex].Barcode = selectedItemCodeTB.Text;
                productList[productslistDatagrid.SelectedIndex].Name = selectedItemNameTB.Text;
                productList[productslistDatagrid.SelectedIndex].Price = result;
                productslistDatagrid.Items.Refresh();
                selectedItemVb.Visibility = Visibility.Hidden;
            }
        }
        private void deleteRowBtn_Click(object sender, RoutedEventArgs e)
        {
            Confirmation dc = new Confirmation(productList[productslistDatagrid.SelectedIndex].Barcode);
            dc.Owner = this;
            dc.ShowDialog();
            if (dc.confirmationBool)
            {
                selectionChange = false;
                productList.RemoveAt(productslistDatagrid.SelectedIndex);
                productslistDatagrid.Items.Refresh();
                selectedItemVb.Visibility = Visibility.Hidden;
            }
        }

        private void newRowBtn_Click(object sender, RoutedEventArgs e)
        {
            newProduct();
        }

        private void newProduct()
        {
            NewItem ni = new NewItem(globalBarcode,productList);
            globalBarcode = "";
            ni.Owner = this;
            ni.ShowDialog();
            try
            {

                productList.Add(new Products(ni.code + ";" + ni.name + ";0;" + ni.price));
            }
            catch (Exception) { }
            productslistDatagrid.Items.Refresh();
        }

        private void selectedItemCodeTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                selectedItemNameTB.Focus();
                selectedItemNameTB.CaretIndex = selectedItemNameTB.Text.Length;
            }
        }

        private void selectedItemNameTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                selectedItemPriceTB.Focus();
                selectedItemPriceTB.CaretIndex = selectedItemPriceTB.Text.Length;
            }
        }
        private void selectedItemPriceTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                saveRowModification();
            }
        }
        //tab 2
        private void supplyAddBtn_Click(object sender, RoutedEventArgs e)
        {
            addSupply();
        }

        private void addSupply()
        {
            if (!productList.Any(x => x.Barcode == supplyBarcodeTB.Text))
            {
                missingBarcode mb = new missingBarcode();
                mb.Owner = this;
                mb.ShowDialog();
                if (mb.newItem)
                {
                    globalBarcode = supplyBarcodeTB.Text;
                    newProduct();
                }
            }
            else if (!int.TryParse(supplyAmountTB.Text, out int asd))
                MessageBox.Show("Hibás a mennyiség formátuma!");
            else if (int.Parse(supplyAmountTB.Text) < 1)
                MessageBox.Show("Nem adhatsz meg egynél kevesebb mennyiséget!");
            else
            {
                if (supplyList.Any(x => x.Barcode == supplyBarcodeTB.Text))
                {
                    supplyList.Where(x => x.Barcode == supplyBarcodeTB.Text).First().Amount += int.Parse(supplyAmountTB.Text);

                }
                else
                {
                    supplyList.Add(new supply(supplyBarcodeTB.Text + ";" + productList.Where(x => x.Barcode == supplyBarcodeTB.Text).First().Name + ";" + supplyAmountTB.Text));

                }
            }
            supplyBarcodeTB.Text = "";
            supplyAmountTB.Text = "";
            supplyBarcodeTB.Focus();
            supplyDatagrid.Items.Refresh();
        }

        private void supplyBarcodeTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                supplyAmountTB.Focus();
        }

        private void supplyAmountTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                addSupply();
        }
        private void supplyDeleteRowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (supplyDatagrid.SelectedIndex>-1&&supplyDatagrid.SelectedIndex<supplyList.Count)
            {
                Confirmation dc = new Confirmation(supplyList[supplyDatagrid.SelectedIndex].Barcode);
                dc.Owner = this;
                dc.ShowDialog();
                if (dc.confirmationBool)
                {
                    supplyList.RemoveAt(supplyDatagrid.SelectedIndex);
                    supplyDatagrid.Items.Refresh();
                }
            }
        }

        private void supplyModifyRowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (supplyDatagrid.SelectedIndex > -1 && supplyDatagrid.SelectedIndex < supplyList.Count)
            {
                amount_change ac = new amount_change(supplyList[supplyDatagrid.SelectedIndex].Amount);
                ac.Owner = this;
                ac.ShowDialog();
                supplyList[supplyDatagrid.SelectedIndex].Amount = ac.changedAmount;
                supplyDatagrid.Items.Refresh();
            }
        }

        private void supplyUploadRowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (supplyList.Count != 0)
            {
                Confirmation dc = new Confirmation("save");
                dc.Owner = this;
                dc.ShowDialog();
                if (dc.confirmationBool)
                {
                    for (int i = 0; i < supplyList.Count; i++)
                    {
                        productList.Where(x => x.Barcode == supplyList[i].Barcode).First().Amount+=supplyList[i].Amount;
                    }
                    supplyList.Clear();
                    supplyDatagrid.Items.Refresh();
                    productslistDatagrid.Items.Refresh();
                }
            }
        }

        private void supplyCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (supplyList.Count != 0)
            {
                Confirmation dc = new Confirmation("cancel");
                dc.Owner = this;
                dc.ShowDialog();
                if (dc.confirmationBool)
                {
                    supplyList.Clear();
                    supplyDatagrid.Items.Refresh();
                }
            }
        }

        //tab 3
        private void salesBarcodeTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                salesAmountTB.Focus();
                salesAmountTB.Select(0, salesAmountTB.Text.Length);
            }
        }

        private void salesAmountTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                addSales();
        }

        private void salesAddBtn_Click(object sender, RoutedEventArgs e)
        {
            addSales();
        }

        private void addSales()
        {
            if (productList.Any(x => x.Barcode == salesBarcodeTB.Text))
                if (int.TryParse(salesAmountTB.Text, out int result))
                {
                    int listAmount=0;
                    if (salesList.Any(x => x.Barcode == salesBarcodeTB.Text))
                        listAmount = salesList.Where(x => x.Barcode == salesBarcodeTB.Text).First().Amount;
                    if ((listAmount+result)<=productList.Where(x=>x.Barcode==salesBarcodeTB.Text).First().Amount &&  result>0)
                    {
                        if (salesList.Any(x => x.Barcode == salesBarcodeTB.Text))
                            salesList.Where(x => x.Barcode == salesBarcodeTB.Text).First().Amount += result;
                        else
                            salesList.Add(new Products(salesBarcodeTB.Text + ";" + productList.Where(x => x.Barcode == salesBarcodeTB.Text).First().Name + ";" + result + ";" + productList.Where(x => x.Barcode == salesBarcodeTB.Text).First().Price));
                        requiredMoney += productList.Where(x => x.Barcode == salesBarcodeTB.Text).First().Price * result;
                        priceLb.Content = Math.Round(requiredMoney,0) + " Ft";
                        salesBarcodeTB.Text = "";
                        salesAmountTB.Text = "1";
                        salesBarcodeTB.Focus();
                        salesDatagrid.Items.Refresh();
                    }
                    else if (result<1)
                    {
                        MessageBox.Show("Nem vehetsz egynél kevesebbet!");
                        salesAmountTB.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Nem vehetsz többet mint ami a raktáron van!");
                        salesAmountTB.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Hibás mennyiséget adtál meg!");
                    salesAmountTB.Focus();
                }
            else
            {
                MessageBox.Show("Hibás vonalkód!");
                salesBarcodeTB.Focus();
            }
        }

        private void salesDeleteRowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (salesDatagrid.SelectedIndex > -1 && salesDatagrid.SelectedIndex < salesList.Count)
            {
                Confirmation dc = new Confirmation(salesList[salesDatagrid.SelectedIndex].Barcode);
                dc.Owner = this;
                dc.ShowDialog();
                if (dc.confirmationBool)
                {
                    requiredMoney -= salesList[salesDatagrid.SelectedIndex].Amount * salesList[salesDatagrid.SelectedIndex].Price;
                    salesList.RemoveAt(salesDatagrid.SelectedIndex);
                    salesDatagrid.Items.Refresh();
                }
            }
        }

        private void salesModifyRowBtn_Click(object sender, RoutedEventArgs e)
        {
            salesValidNumber();
        }

        private void salesValidNumber()
        {
            if (salesDatagrid.SelectedIndex > -1 && salesDatagrid.SelectedIndex < salesList.Count)
            {
                amount_change ac = new amount_change(salesList[salesDatagrid.SelectedIndex].Amount);
                ac.Owner = this;
                ac.ShowDialog();
                if (ac.changedAmount <= productList.Where(x => x.Barcode == salesList[salesDatagrid.SelectedIndex].Barcode).First().Amount && ac.changedAmount > 0)
                    salesList[salesDatagrid.SelectedIndex].Amount = ac.changedAmount;
                else
                {
                    MessageBox.Show("Nem vehetsz többet mint ami a raktáron van!");
                    salesValidNumber();
                }
                salesDatagrid.Items.Refresh();
            }
        }

        private void salesSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            bool validList = true;
            for (int i = 0; i < salesList.Count; i++)
                if (!(salesList[i].Amount>productList.Where(x=>x.Barcode==salesList[i].Barcode).First().Amount))
                    validList = false;
            if (validList)
            {
                if (salesList.Count != 0)
                { 
                    Confirmation dc = new Confirmation("purchaseEnd");
                    dc.Owner = this;
                    dc.ShowDialog();
                    if (dc.confirmationBool)
                    {
                        for (int i = 0; i < salesList.Count; i++)
                        {
                            if (productList.Any(x=>x.Barcode==salesList[i].Barcode))
                            {
                                productList.Where(x => x.Barcode == salesList[i].Barcode).First().Amount -= salesList[i].Amount;
                            }
                        }
                        if (priceCb.IsChecked==true)
                        {
                            string asd = Math.Round(requiredMoney, 0).ToString();
                            if (int.Parse(asd[asd.Length-1].ToString())>0 && int.Parse(asd[asd.Length-1].ToString()) < 6)
                            {
                                asd = asd.Remove(asd.Length - 1, 1);
                                MessageBox.Show("A fizetendő összeg:\n" + asd + "5");
                            }
                            else
                            {
                                asd = asd.Remove(asd.Length - 1, 1);
                                MessageBox.Show("A fizetendő összeg:\n" + asd + "0");
                            }
                        }
                        else
                        {
                            MessageBox.Show("A fizetendő összeg: " + Math.Round(requiredMoney,0)+" Ft");
                        }
                        requiredMoney = 0;
                        priceLb.Content = "0Ft";
                        salesList.Clear();
                        productslistDatagrid.Items.Refresh();
                        salesDatagrid.Items.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("Valamiböl több van a listán mint raktáron");
            }
        }

        private void salesCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Confirmation dc = new Confirmation("purchaseCancel");
            dc.Owner = this;
            dc.ShowDialog();
            if (dc.confirmationBool)
            {
                requiredMoney = 0;
                priceLb.Content = "0Ft";
                salesList.Clear();
                salesDatagrid.Items.Refresh();
            }
        }
    }
}
