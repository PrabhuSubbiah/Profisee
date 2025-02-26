using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Web.Mvc;
using System.Web.ModelBinding;

namespace BeSpokedApp.Utilities
{
    public static class UtilityClass
    {
            public static string GetAPIUri()
            {
                string url = ConfigurationManager.AppSettings.Get("BESpokedURI");

                return url;
            }
            public static HttpClient GetHTTPClient()
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(GetAPIUri());
                //            client.DefaultRequestHeaders.Add("Accept-Language", "en-GB,en-US;q=0.8,en;q=0.6,ru;q=0.4");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
                ServicePointManager.ServerCertificateValidationCallback = new
                RemoteCertificateValidationCallback
                (
                    delegate { return true; }
                );
                return client;
            }
        public static IEnumerable<T> GetLookUps<T>(T typeOfLookup)
        {
            IEnumerable<T> lookups = null;

            using (var client = UtilityClass.GetHTTPClient())
            {
                var responseTask = client.GetAsync(string.Format(@"api/BeSpokeBus/" + GetFunctionNameForLookup(typeOfLookup)));
                responseTask.Wait();

                var result = (HttpResponseMessage)responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<T>>();
                    readTask.Wait();

                    lookups =(IEnumerable<T>) readTask.Result;
                }
                else //web api sent error response 
                {
                    if (result.StatusCode == HttpStatusCode.NotAcceptable)
                    {
                        string outStr = result.Content.ReadAsStringAsync().Result;
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
            return lookups;
        }
        private static string GetFunctionNameForLookup<T>(T typeName)
        {
            switch(typeName.GetType().Name)
            {
                case "StyleLookUp" :
                    return "GetStyleLookUps";
                case "ManagerLookUp":
                    return "GetManagerLookUps";
                case "CustomerLookUp":
                    return "GetCustomerLookUps";
                case "SalesPersonLookUp":
                    return "GetSalesPersonLookUps";
                case "ProductLookUp":
                    return "GetProductLookUps";
                default:
                    return "GetStyleLookUps";
            }

        }
    }
}