using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdidatcuongMVC.Models
{
    public class Order_Detail
    {
        public int ID { set; get; }
        public String OrderID { set; get; }
        public String ProductID { set; get; }
        public decimal Quantity { set; get; }
    }
}
