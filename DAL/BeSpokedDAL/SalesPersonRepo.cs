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
    public class SalesPersonRepo : IMaintainRepo<SalesPerson>
    {
        private BeSpokedConStr _dbContext = null;

        public SalesPersonRepo()
        {
            _dbContext = new BeSpokedConStr();
        }
        public void Create(SalesPerson obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalesPerson> GetAll()
        {
            return _dbContext.sales_person.ToList().Select(x => x.MapToSalesPerson());
        }

        public SalesPerson GetById(int id)
        {
            var salesPerson = _dbContext.sales_person.ToList().FirstOrDefault(x => x.id == id);
            if (salesPerson != null)
            {
                return salesPerson.MapToSalesPerson();
            }
            return null;
        }

        public IEnumerable<SalesPerson> GetFilteredList(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void Update(SalesPerson obj)
        {
            sales_person sal = obj.MapFromSalesPerson();
            var duplicate = _dbContext.sales_person.FirstOrDefault(x => x.first_name == sal.first_name && x.last_name == sal.last_name && x.phone == sal.phone);
            if (duplicate != null)
                return;

            sales_person refferal = _dbContext.sales_person.FirstOrDefault(x => x.id == sal.id);
            if (refferal != null)
            {
                refferal.id = sal.id;
                refferal.first_name = sal.first_name;
                refferal.last_name = sal.last_name;
                refferal.address = sal.address;
                refferal.phone = sal.phone;
                refferal.start_date = sal.start_date;
                refferal.termination_date = sal.termination_date;
                refferal.manager_id = sal.manager_id;
                _dbContext.SaveChanges();
            }
        }
    }
}
