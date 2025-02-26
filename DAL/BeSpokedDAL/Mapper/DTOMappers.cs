using BeSpokedDAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeSpokedDAL.Mapper
{
    public static class DTOMappers
    {
        public static Product MapToProduct(this product source)
        {
            return new Product()  {
                id  = source.id,
                manufacturer = source.manufacturer,
                style_id = source.style_id,
                style_name = source.style.style1, 
                purchase_price = source.purchase_price,
                sales_price = source.sales_price,
                quantity = source.quantity,
                commission = source.commission
            };
        }

        public static product MapFromProduct(this Product source)
        {
            return new product()
            {
                id = source.id,
                manufacturer = source.manufacturer,
                style_id = source.style_id,
                purchase_price = source.purchase_price,
                sales_price = source.sales_price,
                quantity = source.quantity,
                commission = source.commission
            };
        }

        public static Customer MapToCustomer(this customer source)
        {
            return new Customer()
            {
                id = source.id,
                first_name = source.first_name,
                last_name = source.last_name,
                address = source.address,
                phone = source.phone,
                start_date = source.start_date
            };
        }
        public static customer MapFromCustomer(this Customer source)
        {
            return new customer()
            {
                id = source.id,
                first_name = source.first_name,
                last_name = source.last_name,
                address = source.address,
                phone = source.phone,
                start_date = source.start_date
            };
        }
        public static SalesPerson MapToSalesPerson(this sales_person source)
        {
            return new SalesPerson()
            {
                id = source.id,
                first_name = source.first_name,
                last_name = source.last_name,
                address = source.address,
                phone = source.phone,
                start_date = source.start_date,
                termination_date = source.termination_date,
                manager_id = source.manager_id,
                manager_name = source.manager.last_name + ' ' + source.manager.first_name
            };
        }
        public static sales_person MapFromSalesPerson(this SalesPerson source)
        {
            return new sales_person()
            {
                id = source.id,
                first_name = source.first_name,
                last_name = source.last_name,
                address = source.address,
                phone = source.phone,
                start_date = source.start_date,
                termination_date = source.termination_date,
                manager_id = source.manager_id
            };
        }
        public static Sales MapToSales(this sale source)
        {
            return new Sales()
            {
                id = source.id,
                product_id = source.product_id,
                product_name = source.product.manufacturer,
                customer_id = source.customer_id,
                customer_name = source.customer.last_name + ' ' + source.customer.first_name,
                sales_person_id = source.sales_person_id,
                sales_person_name = source.sales_person.last_name + ' ' + source.sales_person.first_name,
                sales_date = source.sales_date,
                commision_earned = (source.product.commission / 100) * CalculateDiscountedSalesPrice(source),
                price = source.product.sales_price
            };
        }
        public static sale MapFromSales(this Sales source)
        {
            return new sale()
            {
                id = source.id,
                product_id = source.product_id,
                customer_id = source.customer_id,
                sales_person_id = source.sales_person_id,
                sales_date = source.sales_date
            };
        }
        public static sale MapFromCustomer(this sale target, Sales source)
        {
            target.id = source.id;
            target.product_id = source.product_id;
            target.customer_id = source.customer_id;
            target.sales_person_id = source.sales_person_id;
            target.sales_date = source.sales_date;

            return target;
        }
        private static decimal CalculateDiscountedSalesPrice(sale source)
        {
            decimal retVal = 0;
            var discount = source.product.discounts.FirstOrDefault(x => x.begin_date < DateTime.Now && x.end_date > DateTime.Now);
            if (discount != null)
            {
                return source.product.sales_price - ((discount.discount1 / 100) * source.product.sales_price);
            }
            return retVal;
        }
    }
}
