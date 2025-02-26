using BeSpokedDAL.Abstraction;
using BeSpokedDAL.DTO;
using BeSpokedDAL.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSpokedDAL
{
    public class CustomerRepo : IMaintainRepo<Customer>
    {
        private BeSpokedConStr _dbContext = null;
        public CustomerRepo()
        {
            _dbContext = new BeSpokedConStr();
        }
        public void Create(Customer obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _dbContext.customers.ToList().Select(x => x.MapToCustomer());
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetFilteredList(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}
