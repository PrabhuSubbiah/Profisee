using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSpokedDAL.DTO
{
    public class SalesPerson
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime termination_date { get; set; }
        public int manager_id { get; set; }
        public string manager_name { get; set; }
    }
}
