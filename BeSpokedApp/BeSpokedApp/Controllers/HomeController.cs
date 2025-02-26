using BeSpokedApp.Models;
using BeSpokedApp.Utilities;
using BeSpokedDAL.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BeSpokedApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<Customer> customerList = null;
            using (var client = UtilityClass.GetHTTPClient())
            {
                var responseTask = client.GetAsync(string.Format(@"api/BeSpokeBus/GetCustomerList"));
                responseTask.Wait();

                var result = (HttpResponseMessage)responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Customer>>();
                    readTask.Wait();

                    customerList = readTask.Result;
                }
                else //web api sent error response 
                {
                    if (result.StatusCode == HttpStatusCode.NotAcceptable)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        ModelState.AddModelError(string.Empty, outStr);
                    }
                    else if (result.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        Exception ex = new Exception(outStr);
                        throw ex;
                    }
                    else if (result.StatusCode == HttpStatusCode.ExpectationFailed)
                    {
                        Exception ex = result.Content.ReadAsStringAsync().Exception;
                        throw ex;
                    }
                }
            }
            return View("CustomerListView", customerList);
        }

        public ActionResult Products()
        {
            ViewBag.Message = "Products.";

            IEnumerable<Product> productList = null;
            using (var client = UtilityClass.GetHTTPClient())
            {
                var responseTask = client.GetAsync(string.Format(@"api/BeSpokeBus/GetProductList"));
                responseTask.Wait();

                var result = (HttpResponseMessage)responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Product>>();
                    readTask.Wait();

                    productList = readTask.Result;
                }
                else //web api sent error response 
                {
                    if (result.StatusCode == HttpStatusCode.NotAcceptable)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        ModelState.AddModelError(string.Empty, outStr);
                    }
                    else if (result.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        Exception ex = new Exception(outStr);
                        throw ex;
                    }
                    else if (result.StatusCode == HttpStatusCode.ExpectationFailed)
                    {
                        Exception ex = result.Content.ReadAsStringAsync().Exception;
                        throw ex;
                    }
                }
            }
            return View("ProductsListView", productList);
        }

        public ActionResult SalesPersons()
        {
            ViewBag.Message = "Your contact page.";

            IEnumerable<SalesPerson> salesPersonList = null;
            using (var client = UtilityClass.GetHTTPClient())
            {
                var responseTask = client.GetAsync(string.Format(@"api/BeSpokeBus/GetSalesPersonList"));
                responseTask.Wait();

                var result = (HttpResponseMessage)responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<SalesPerson>>();
                    readTask.Wait();

                    salesPersonList = readTask.Result;
                }
                else //web api sent error response 
                {
                    if (result.StatusCode == HttpStatusCode.NotAcceptable)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        ModelState.AddModelError(string.Empty, outStr);
                    }
                    else if (result.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        Exception ex = new Exception(outStr);
                        throw ex;
                    }
                    else if (result.StatusCode == HttpStatusCode.ExpectationFailed)
                    {
                        Exception ex = result.Content.ReadAsStringAsync().Exception;
                        throw ex;
                    }
                }
            }
            return View("SalesPersonListView", salesPersonList);
        }
        public ActionResult Sales()
        {

            IEnumerable<Sales> salesList = null;
            using (var client = UtilityClass.GetHTTPClient())
            {
                var responseTask = client.GetAsync(string.Format(@"api/BeSpokeBus/GetSalesList"));
                responseTask.Wait();

                var result = (HttpResponseMessage)responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Sales>>();
                    readTask.Wait();

                    salesList = readTask.Result;
                }
                else //web api sent error response 
                {
                    if (result.StatusCode == HttpStatusCode.NotAcceptable)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        ModelState.AddModelError(string.Empty, outStr);
                    }
                    else if (result.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        Exception ex = new Exception(outStr);
                        throw ex;
                    }
                    else if (result.StatusCode == HttpStatusCode.ExpectationFailed)
                    {
                        Exception ex = result.Content.ReadAsStringAsync().Exception;
                        throw ex;
                    }
                }
            }
            return View("SalesListView", salesList);
        }
        public ActionResult SalesSearch(DateTime fromDate, DateTime toDate)
        {
            IEnumerable<Sales> salesList = null;
            using (var client = UtilityClass.GetHTTPClient())
            {
                var responseTask = client.GetAsync(string.Format(@"api/BeSpokeBus/GetSearchSalesList?fromDate={0}&toDate={1}", fromDate.ToShortDateString(), toDate.ToShortDateString()));
                responseTask.Wait();

                var result = (HttpResponseMessage)responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Sales>>();
                    readTask.Wait();

                    salesList = readTask.Result;
                }
                else //web api sent error response 
                {
                    if (result.StatusCode == HttpStatusCode.NotAcceptable)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        ModelState.AddModelError(string.Empty, outStr);
                    }
                    else if (result.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        Exception ex = new Exception(outStr);
                        throw ex;
                    }
                    else if (result.StatusCode == HttpStatusCode.ExpectationFailed)
                    {
                        Exception ex = result.Content.ReadAsStringAsync().Exception;
                        throw ex;
                    }
                }
            }
            return View("SalesListView", salesList);
        }
        public ActionResult Reports()
        {
            ViewBag.Message = "Quarterly Reports.";

            IEnumerable<SalesReport> quarterlyList = null;
            using (var client = UtilityClass.GetHTTPClient())
            {
                var responseTask = client.GetAsync(string.Format(@"api/BeSpokeBus/GetQuarterlyReport"));
                responseTask.Wait();

                var result = (HttpResponseMessage)responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<SalesReport>>();
                    readTask.Wait();

                    quarterlyList = readTask.Result;
                }
                else //web api sent error response 
                {
                    if (result.StatusCode == HttpStatusCode.NotAcceptable)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        ModelState.AddModelError(string.Empty, outStr);
                    }
                    else if (result.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        Exception ex = new Exception(outStr);
                        throw ex;
                    }
                    else if (result.StatusCode == HttpStatusCode.ExpectationFailed)
                    {
                        Exception ex = result.Content.ReadAsStringAsync().Exception;
                        throw ex;
                    }
                }
            }
            return View("QuarterlyRptView", quarterlyList);
        }
        public ActionResult UpdateProduct(int id)
        {
            Product product = null;
            using (var client = UtilityClass.GetHTTPClient())
            {
                var responseTask = client.GetAsync(string.Format(@"api/BeSpokeBus/GetProductById/" + id.ToString()));
                responseTask.Wait();

                var result = (HttpResponseMessage)responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Product>();
                    readTask.Wait();

                    product = readTask.Result;
                }
                else //web api sent error response 
                {
                    if (result.StatusCode == HttpStatusCode.NotAcceptable)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        ModelState.AddModelError(string.Empty, outStr);
                    }
                    else if (result.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        Exception ex = new Exception(outStr);
                        throw ex;
                    }
                    else if (result.StatusCode == HttpStatusCode.ExpectationFailed)
                    {
                        Exception ex = result.Content.ReadAsStringAsync().Exception;
                        throw ex;
                    }
                }
            }
            ViewBag.StyleLookup = UtilityClass.GetLookUps(new StyleLookUp());
            return PartialView("_UpdateProductView", product.MapToProductViewModel());
        }
        
        [HttpPost]
        public ActionResult SaveProduct(ProductViewModel productViewModel)
        {
            //if (!ModelState.IsValid)
            //    return View();

            var product = productViewModel.MapFromProductViewModel();
            using (var client = UtilityClass.GetHTTPClient())
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(product), System.Text.Encoding.UTF8, "application/json");
                var responseTask = client.PostAsync(string.Format(@"api/BeSpokeBus/PostProductChanges"), httpContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode)
                {
                    if (result.StatusCode == HttpStatusCode.NotAcceptable)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        ModelState.AddModelError(string.Empty, outStr);
                    }
                    else if (result.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        Exception ex = new Exception(outStr);
                        throw ex;
                    }
                    else if (result.StatusCode == HttpStatusCode.ExpectationFailed)
                    {
                        Exception ex = result.Content.ReadAsStringAsync().Exception;
                        throw ex;
                    }
                }
            }
            return RedirectToAction("Products");
        }
        public ActionResult UpdateSalesPerson(int id)
        {
            SalesPerson salesPerson = null;
            using (var client = UtilityClass.GetHTTPClient())
            {
                var responseTask = client.GetAsync(string.Format(@"api/BeSpokeBus/GetSalesPersonById/" + id.ToString()));
                responseTask.Wait();

                var result = (HttpResponseMessage)responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<SalesPerson>();
                    readTask.Wait();

                    salesPerson = readTask.Result;
                }
                else //web api sent error response 
                {
                    if (result.StatusCode == HttpStatusCode.NotAcceptable)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        ModelState.AddModelError(string.Empty, outStr);
                    }
                    else if (result.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        Exception ex = new Exception(outStr);
                        throw ex;
                    }
                    else if (result.StatusCode == HttpStatusCode.ExpectationFailed)
                    {
                        Exception ex = result.Content.ReadAsStringAsync().Exception;
                        throw ex;
                    }
                }
            }
            ViewBag.ManagerLookup = UtilityClass.GetLookUps(new ManagerLookUp());
            return PartialView("_UpdateSalesPersonView", salesPerson.MapToSalesPersonViewModel());
        }

        [HttpPost]
        public ActionResult SaveSalesPerson(SalesPersonViewModel salesPersonViewModel)
        {
            //if (!ModelState.IsValid)
            //    return View();

            var salesPerson = salesPersonViewModel.MapFromSalesPersonViewModel();
            using (var client = UtilityClass.GetHTTPClient())
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(salesPerson), System.Text.Encoding.UTF8, "application/json");
                var responseTask = client.PostAsync(string.Format(@"api/BeSpokeBus/PostSalesPersonChanges"), httpContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode)
                {
                    if (result.StatusCode == HttpStatusCode.NotAcceptable)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        ModelState.AddModelError(string.Empty, outStr);
                    }
                    else if (result.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        Exception ex = new Exception(outStr);
                        throw ex;
                    }
                    else if (result.StatusCode == HttpStatusCode.ExpectationFailed)
                    {
                        Exception ex = result.Content.ReadAsStringAsync().Exception;
                        throw ex;
                    }
                }
            }
            return RedirectToAction("SalesPersons");
        }

        public ActionResult AddNewSales()
        {
            ViewBag.ProductLookup = UtilityClass.GetLookUps(new ProductLookUp());
            ViewBag.CustomerLookup = UtilityClass.GetLookUps(new CustomerLookUp());
            ViewBag.SalesPersonLookup = UtilityClass.GetLookUps(new SalesPersonLookUp());
            return PartialView("_AddSales");
        }

        [HttpPost]
        public ActionResult SaveSales(SalesViewModel salesViewModel)
        {
            //if (!ModelState.IsValid)
            //    return View();

            var sales = salesViewModel.MapFromSalesViewModel();
            using (var client = UtilityClass.GetHTTPClient())
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(sales), System.Text.Encoding.UTF8, "application/json");
                var responseTask = client.PostAsync(string.Format(@"api/BeSpokeBus/PostSalesChanges"), httpContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (!result.IsSuccessStatusCode)
                {
                    if (result.StatusCode == HttpStatusCode.NotAcceptable)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        ModelState.AddModelError(string.Empty, outStr);
                    }
                    else if (result.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
                        Exception ex = new Exception(outStr);
                        throw ex;
                    }
                    else if (result.StatusCode == HttpStatusCode.ExpectationFailed)
                    {
                        Exception ex = result.Content.ReadAsStringAsync().Exception;
                        throw ex;
                    }
                }
            }
            return RedirectToAction("Sales");
        }
    }
}