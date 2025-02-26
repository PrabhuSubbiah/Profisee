using BeSpokedDAL.Abstraction;
using BeSpokedDAL.DTO;
using BeSpokedDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeSpokedApp.API
{
    public class BeSpokeBusController : BaseController
    {
        // GET api/<controller>
        public IHttpActionResult GetCustomerList()
        {
            IMaintainRepo<Customer> iCustomer = new CustomerRepo();
            IEnumerable<Customer> customerList =  iCustomer.GetAll();

                if (customerList == null)
                {
                    var message = string.Format("No customer found");
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, message));
                }
                return Ok(customerList);
        }

        public IHttpActionResult GetSalesPersonList()
        {
            IMaintainRepo<SalesPerson> iSalesPerson = new SalesPersonRepo();
            IEnumerable<SalesPerson> salesPersonList = iSalesPerson.GetAll();

            if (salesPersonList == null)
            {
                var message = string.Format("No Sales Persons found");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, message));
            }
            return Ok(salesPersonList);
        }

        public IHttpActionResult GetSalesList()
        {
            IMaintainRepo<Sales> iSales = new SalesRepo();
            IEnumerable<Sales> salesList = iSales.GetAll();

            if (salesList == null)
            {
                var message = string.Format("No Sales found");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, message));
            }
            return Ok(salesList);
        }
        public IHttpActionResult GetSearchSalesList(string fromDate, string toDate)
        {
            IMaintainRepo<Sales> iSales = new SalesRepo();
            IEnumerable<Sales> salesList = iSales.GetFilteredList(Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate));

            if (salesList == null)
            {
                var message = string.Format("No Sales found");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, message));
            }
            return Ok(salesList);
        }
        public IHttpActionResult GetProductList()
        {
            IMaintainRepo<Product> iProduct = new ProductRepo();
            IEnumerable<Product> productList = iProduct.GetAll();

            if (productList == null)
            {
                var message = string.Format("No Products found");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, message));
            }
            return Ok(productList);
        }
        public IHttpActionResult GetQuarterlyReport()
        {
            ISalesReport iSales = new SalesRepo();
            IEnumerable<SalesReport> salesList = iSales.GetQuarterlySalesPersonReport(DateTime.Now);

            if (salesList == null)
            {
                var message = string.Format("No Sales found");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, message));
            }
            return Ok(salesList);
        }
        public IHttpActionResult GetStyleLookUps()
        {
            IDALLookUps iLookup = new DALLookUps();
            IEnumerable<StyleLookUp> lookUp = iLookup.GetStyleLookupList();

            if (lookUp == null)
            {
                var message = string.Format("No list found");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, message));
            }
            return Ok(lookUp.ToList());
        }
        public IHttpActionResult GetManagerLookUps()
        {
            IDALLookUps iLookup = new DALLookUps();
            IEnumerable<ManagerLookUp> lookUp = iLookup.GetManagerLookupList();

            if (lookUp == null)
            {
                var message = string.Format("No list found");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, message));
            }
            return Ok(lookUp);
        }
        public IHttpActionResult GetCustomerLookUps()
        {
            IDALLookUps iLookup = new DALLookUps();
            IEnumerable<CustomerLookUp> lookUp = iLookup.GetCustomerLookupList();

            if (lookUp == null)
            {
                var message = string.Format("No list found");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, message));
            }
            return Ok(lookUp);
        }
        public IHttpActionResult GetSalesPersonLookUps()
        {
            IDALLookUps iLookup = new DALLookUps();
            IEnumerable<SalesPersonLookUp> lookUp = iLookup.GetSalesPersonLookupList();

            if (lookUp == null)
            {
                var message = string.Format("No list found");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, message));
            }
            return Ok(lookUp);
        }
        public IHttpActionResult GetProductLookUps()
        {
            IDALLookUps iLookup = new DALLookUps();
            IEnumerable<ProductLookUp> lookUp = iLookup.GetProductLookupList();

            if (lookUp == null)
            {
                var message = string.Format("No list found");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, message));
            }
            return Ok(lookUp);
        }
        public IHttpActionResult GetProductById(int id)
        {
            IMaintainRepo<Product> iProduct = new ProductRepo();
            Product product = iProduct.GetById(id);

            if (product == null)
            {
                var message = string.Format("No product found");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, message));
            }
            return Ok(product);
        }
        public IHttpActionResult PostProductChanges(Product product)
        {
            IMaintainRepo<Product> iProduct = new ProductRepo();

            iProduct.Update(product);

            return Ok();
        }
        public IHttpActionResult GetSalesPersonById(int id)
        {
            IMaintainRepo<SalesPerson> iSalesPerson = new SalesPersonRepo();
            SalesPerson salesPerson = iSalesPerson.GetById(id);

            if (salesPerson == null)
            {
                var message = string.Format("No product found");
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, message));
            }
            return Ok(salesPerson);
        }
        public IHttpActionResult PostSalesPersonChanges(SalesPerson salesPerson)
        {
            IMaintainRepo<SalesPerson> iSalesPerson = new SalesPersonRepo();

            iSalesPerson.Update(salesPerson);

            return Ok();
        }
        public IHttpActionResult PostSalesChanges(Sales sales)
        {
            IMaintainRepo<Sales> iSales = new SalesRepo();

            iSales.Create(sales);

            return Ok();
        }
        
    }
}