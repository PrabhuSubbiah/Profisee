using BeSpokedDAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSpokedDAL.Abstraction
{
    public interface ISalesReport
    {
        IEnumerable<SalesReport> GetQuarterlySalesPersonReport(DateTime dt);
    }
}
