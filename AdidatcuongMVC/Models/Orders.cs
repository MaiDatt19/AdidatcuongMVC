using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdidatcuongMVC.Models
{
    public class Orders
    {
        public int ID { set; get; }
        public String OrderID { get; }
        public String AgentEmail { set; get; }
        public String OrderDay { set; get; }
        public String Status { set; get; }
        public decimal TotalMoney { set; get; }


    }
}
