using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace VinmonopoletWineSalesFigures
{
    public class ApiProvider
    {
        public ApiProvider()
        {
        }
        HttpClient httpClient = new HttpClient();
        static string baseUrl = "https://apis.vinmonopolet.no";
        static string productPrefix = "/products/v0/details-normal";
        static string produtEndpoint = "?productShortNameContains=";
        static string productApiUrl = baseUrl + productPrefix + produtEndpoint;

        static string storePrefix = "/stores/v0/details";
        static string storeEndpoint = "?storeId=";
        static string storeApiUrl = baseUrl + storePrefix + storeEndpoint;

        static string salesPrefix = "/products/v0/monthly-sales-per-store";
        static string salesEndpoint = "?fromStoreID= {fromstoreID} & toStoreID= {toStoreID} & fromSalesMonth={fromSalesMonth} & toSalesMonth={toSalesMonth}";
        static string salesApiUrl = baseUrl + salesPrefix + salesEndpoint;

        async public Task<List<WineDetails>> getWineDetaillsByName(string wineName)
        {
            productApiUrl = productApiUrl + wineName;
            HttpMethod httpMethod = HttpMethod.Get;
            HttpRequestMessage request = new HttpRequestMessage(httpMethod, productApiUrl);
            request.Headers.Add("Ocp-Apim-Subscription-Key", "bd1cb1cb56c4441b9eb88eb391450963");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<WineDetails> wineDetails = JsonConvert.DeserializeObject<List<WineDetails>>(responseBody);

                //List<WineDetails> wineDetails = WineDetails.FromJson(responseBody);
                //foreach (WineDetails winedetail in wineDetails)
                //{
                //    Console.WriteLine("winedetail product short name: " + winedetail.Basic.ProductShortName);

                //}
                //Log step in archeo
                LogStep logStep = new LogStep(responseBody, "Vinos", "List with Amarone from the API", "OK", "getWineDetaillsByName");
                await logStep.LogToArcheo(logStep);
                return wineDetails;
            }
            else
            {
                Console.WriteLine($"GET Request failed with status code: {response.StatusCode}");
            }
            return null;
        }

        async public Task getStoreDetaillsByID(int storeID)
        {
            storeApiUrl = storeApiUrl + storeID;
            HttpMethod httpMethod = HttpMethod.Get;
            HttpRequestMessage request = new HttpRequestMessage(httpMethod, storeApiUrl);
            
            request.Headers.Add("Ocp-Apim-Subscription-Key", "bd1cb1cb56c4441b9eb88eb391450963");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                List<StoreDetails> storeDetails = JsonConvert.DeserializeObject<List<StoreDetails>>(responseBody);
                //foreach (StoreDetails storedetail in storeDetails)
                //{
                //    Console.WriteLine(value: "store detail: " + storedetail.StoreName);

                //}
                //Console.WriteLine("GET Response:");
                //Console.WriteLine(responseBody);
                //Log step in archeo
                LogStep logStep = new LogStep(responseBody, "Vinos", "List of sales figures from Halden", "OK", "getStoreDetaillsByID");
                await logStep.LogToArcheo(logStep);
            }
            else
            {
                Console.WriteLine($"GET Request failed with status code: {response.StatusCode}");
            }
        }

        async public Task<List<SalesDetails>> getSalesDetaillsByID(int fromstoreID, int toStoreID, string fromSalesMonth, string toSalesMonth)
        {
            salesApiUrl= "https://apis.vinmonopolet.no/products/v0/monthly-sales-per-store?fromStoreID=229&toStoreID=229&fromSalesMonth=2022-01-01&toSalesMonth=2022-12-31";
            Console.WriteLine(salesApiUrl);
            HttpMethod httpMethod = HttpMethod.Get;
            HttpRequestMessage request = new HttpRequestMessage(httpMethod, salesApiUrl);
            request.Headers.Add("Ocp-Apim-Subscription-Key", "bd1cb1cb56c4441b9eb88eb391450963");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("GET Response:");
                Console.WriteLine(responseBody);
                List<SalesDetails> saleDetails = JsonConvert.DeserializeObject<List<SalesDetails>>(responseBody);
                //Log step in archeo
                return saleDetails;
               
            } 
            else
            {
                Console.WriteLine($"GET Request failed with status code: {response.StatusCode}");
            }
            return null;

        }
    }
}

