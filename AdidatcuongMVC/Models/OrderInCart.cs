using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdidatcuongMVC.Models
{
    public class OrderInCart
    {
        public AdidatcuongMVC.Models.Product product { set; get; }
        public AdidatcuongMVC.Models.Agent agent { set; get; }
        public AdidatcuongMVC.Models.Orders Orders { set; get; }
        public AdidatcuongMVC.Models.Order_Detail orderDetail { set; get; }

    }
}
