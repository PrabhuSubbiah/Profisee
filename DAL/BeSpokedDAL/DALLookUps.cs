using BeSpokedDAL.Abstraction;
using BeSpokedDAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSpokedDAL
{
    public class DALLookUps : IDALLookUps
    {
        private BeSpokedConStr _dbContext = null;
        public DALLookUps()
        {
            _dbContext = new BeSpokedConStr();
        }
        public IEnumerable<StyleLookUp> GetStyleLookupList()
        {
            return _dbContext.styles.Select(x =>
            new StyleLookUp
            {
                ID = x.id,
                StyleName = x.style1
            }
            );
        }
        public IEnumerable<ManagerLookUp> GetManagerLookupList()
        {
            return _dbContext.managers.Select(x =>
            new ManagerLookUp
            {
                ID = x.id,
                ManagerName = x.last_name + "," + x.first_name
            }
            );
        }
        public IEnumerable<CustomerLookUp> GetCustomerLookupList()
        {
            return _dbContext.customers.Select(x =>
            new CustomerLookUp
            {
                ID = x.id,
                CustomerName = x.last_name + "," + x.first_name
            }
            );
        }
        public IEnumerable<SalesPersonLookUp> GetSalesPersonLookupList()
        {
            return _dbContext.customers.Select(x =>
            new SalesPersonLookUp
            {
                ID = x.id,
                SalesPersonName = x.last_name + "," + x.first_name
            }
            );
        }
        public IEnumerable<ProductLookUp> GetProductLookupList()
        {
            return _dbContext.products.Select(x =>
            new ProductLookUp
            {
                ID = x.id,
                ProductName = x.manufacturer
            }
            );
        }

    }
}
