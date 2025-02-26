using BeSpokedDAL.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSpokedDAL.DTO
{
    public class SalesReport 
    {
        public string SalesPersonName { get; set; }
        public decimal SaleAmountQuarter { get; set; }
        public decimal SalesCommission { get; set; }
    }
}
