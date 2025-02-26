using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSpokedDAL.DTO
{
    public class Sales
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int sales_person_id { get; set; }
        public string sales_person_name { get; set; }
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public System.DateTime sales_date { get; set; }
        public decimal commision_earned { get; set; }
        public decimal price { get; set; }
    }
}
