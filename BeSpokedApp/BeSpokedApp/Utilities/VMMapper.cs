using BeSpokedApp.Models;
using BeSpokedDAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeSpokedApp.Utilities
{
    public static class VMMapper
    {
        public static ProductViewModel MapToProductViewModel(this Product source)
        {
            return new ProductViewModel()
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

        public static Product MapFromProductViewModel(this ProductViewModel source)
        {
            return new Product()
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

    public static SalesPersonViewModel MapToSalesPersonViewModel(this SalesPerson source)
        {
            return new SalesPersonViewModel()
            {
                id = source.id,
                first_name = source.first_name,
                last_name = source.last_name,
                address = source.address,
                phone = source.phone,
                start_date = source.start_date,
                termination_date = source.termination_date,
                manager_id = source.manager_id,
            };
        }
        public static SalesPerson MapFromSalesPersonViewModel(this SalesPersonViewModel source)
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
                manager_id = source.manager_id
            };
        }
        public static SalesViewModel MapToSalesViewModel(this Sales source)
        {
            return new SalesViewModel()
            {
                id = source.id,
                product_id = source.product_id,
                customer_id = source.customer_id,
                sales_person_id = source.sales_person_id,
                sales_date = source.sales_date,
            };
        }
        public static Sales MapFromSalesViewModel(this SalesViewModel source)
        {
            return new Sales()
            {
                id = source.id,
                product_id = source.product_id,
                customer_id = source.customer_id,
                sales_person_id = source.sales_person_id,
                sales_date = source.sales_date,
            };
        }
    }
}