using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Core.Models
{
    public class Checkout
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int PhoneNum { get; set;  }
        public decimal TotalPrice { get; set; }
        public string Adress {  get; set; }


    // we can add more details for orders later 

    }
}