using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdidatcuongMVC.Models
{
    public class Product
    {
        public int ID { set; get; }
        public String ProductID { set; get; }
        public String ProductName { set; get; }
        public decimal Quantity { set; get; }
        public decimal UnitPrice { set; get; }
    }
}
