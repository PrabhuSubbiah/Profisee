using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSpokedDAL.DTO
{
    public class StyleLookUp
    {
        public int ID { get; set; }
        public string StyleName { get; set; }
    }
    public class  ManagerLookUp
    {
        public int ID { get; set; }
        public string ManagerName { get; set; }
    }
    public class ProductLookUp
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
    }
    public class CustomerLookUp
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
    }
    public class SalesPersonLookUp
    {
        public int ID { get; set; }
        public string SalesPersonName { get; set; }
    }

}
