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
    public class SalesRepo : IMaintainRepo<Sales>, ISalesReport
    {
        private BeSpokedConStr _dbContext = null;
        public SalesRepo()
        {
            _dbContext = new BeSpokedConStr();
        }
        public void Create(Sales obj)
        {
            sale sale = obj.MapFromSales();
            _dbContext.sales.Add(sale);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sales> GetAll()
        {
            return _dbContext.sales.ToList().Select(x => x.MapToSales());
        }

        public Sales GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sales> GetFilteredList(DateTime startDate, DateTime endDate)
        {
            return _dbContext.sales.Where(x => x.sales_date >= startDate && x.sales_date <= endDate).ToList().Select(x =>x.MapToSales());
        }

        public IEnumerable<SalesReport> GetQuarterlySalesPersonReport(DateTime dt)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now;
            GetQuarterStartAndEndDate(dt,ref startTime, ref endTime);

            var salesList =  _dbContext.sales.Where(x => x.sales_date >= startTime && x.sales_date <= endTime).ToList().Select(x => x.MapToSales());

            return salesList.GroupBy(x => x.sales_person_id).Select(t =>
                new SalesReport()
                {
                    SalesPersonName = t.First().sales_person_name,
                    SaleAmountQuarter = t.Sum(c => c.price),
                    SalesCommission = t.Sum(c => c.commision_earned)
                }
            );
        }

        public void GetQuarterStartAndEndDate(DateTime date, ref DateTime StartDate, ref DateTime EndDate)
        {
            int quarter = (date.Month - 1) / 3 + 1; // Calculate quarter number
            int firstMonth = (quarter - 1) * 3 + 1; // First month of quarter

            StartDate = new DateTime(date.Year, firstMonth, 1); // Start date of quarter
            EndDate = StartDate.AddMonths(2).AddDays(-1); // End date of quarter

        }
        public void Update(Sales obj)
        {
            throw new NotImplementedException();
        }
    }
}
