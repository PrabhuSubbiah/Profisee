using BeSpokedDAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSpokedDAL.Abstraction
{
    public interface IDALLookUps
    {
        IEnumerable<StyleLookUp> GetStyleLookupList();
        IEnumerable<ManagerLookUp> GetManagerLookupList();
        IEnumerable<CustomerLookUp> GetCustomerLookupList();
        IEnumerable<SalesPersonLookUp> GetSalesPersonLookupList();
        IEnumerable<ProductLookUp> GetProductLookupList();
    }
}
