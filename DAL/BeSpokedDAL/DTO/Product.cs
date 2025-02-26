using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSpokedDAL.DTO
{
    public class Product
    {
        public int id { get; set; }
        public string manufacturer { get; set; }
        public int style_id { get; set; }
        public string style_name { get; set; }
        public decimal purchase_price { get; set; }
        public decimal sales_price { get; set; }
        public int quantity { get; set; }
        public decimal commission { get; set; }
    }
}
