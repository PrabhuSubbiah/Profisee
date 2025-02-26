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
    public class ProductRepo : IMaintainRepo<Product>
    {
        private BeSpokedConStr _dbContext = null;
        public ProductRepo()
        {
            _dbContext = new BeSpokedConStr();
        }

        public void Create(Product obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.products.ToList().Select( x => x.MapToProduct());
        }

        public Product GetById(int id)
        {
            var product =  _dbContext.products.ToList().FirstOrDefault(x => x.id == id);
            if(product != null)
            {
                return product.MapToProduct();
            }
            return null;
        }

        public IEnumerable<Product> GetFilteredList(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void Update(Product obj)
        {
            product prod = obj.MapFromProduct();
            // check for duplicate
            var duplicate = _dbContext.products.FirstOrDefault(x => x.manufacturer == prod.manufacturer && x.style_id == prod.style_id);
            if (duplicate != null)
                return;
            product refferal = _dbContext.products.FirstOrDefault(x => x.id == prod.id);
            if(refferal != null)
            {
                refferal.id = prod.id;
                refferal.manufacturer = prod.manufacturer;
                refferal.style_id = prod.style_id;
                refferal.purchase_price = prod.purchase_price;
                refferal.sales_price = prod.sales_price;
                refferal.quantity = prod.quantity;
                refferal.commission = prod.commission;

                _dbContext.SaveChanges();
            }
        }
    }
}
