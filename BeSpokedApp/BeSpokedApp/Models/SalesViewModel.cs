using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeSpokedApp.Models
{
    public class SalesViewModel
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int sales_person_id { get; set; }
        public int customer_id { get; set; }
        public System.DateTime sales_date { get; set; }
    }
}