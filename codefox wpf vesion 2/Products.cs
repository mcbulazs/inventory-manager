using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codefox_wpf_vesion_2
{
    public class Products
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public Products(string s)
        {
            string[] sor = s.Split(';');
            Barcode = sor[0];
            Name = sor[1];
            Amount = int.Parse(sor[2]);
            Price = double.Parse(sor[3].Replace(",", "."));
        }
    }
    public class supply
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public supply(string s)
        {
            string[] sor = s.Split(';');
            Barcode = sor[0];
            Name = sor[1];
            Amount = int.Parse(sor[2]);
        }
    }
}