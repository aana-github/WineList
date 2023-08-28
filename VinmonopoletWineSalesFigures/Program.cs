using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VinmonopoletWineSalesFigures;

class Program
{
    public static async Task Main(string[] args)
    {
        //  await apiProvider.getStoreDetaillsByID(229);
        ApiProvider apiProvider = new ApiProvider();
        List<WineDetails> wineDetails= await apiProvider.getWineDetaillsByName("Amarone");
        List<SalesDetails> salesDetails = await apiProvider.getSalesDetaillsByID(229,229, "2022-01-01", "2022-12-31");
        List<long>productIdList= wineDetails.Select(x => x.Basic.ProductId).ToList();
//        List<Sale> productsoldList = salesDetails.SelectMany(sd => sd.StoreSales.SelectMany(ss => ss.Sales.Select(p => { productIdList.Contains(p.ProductId); return p; }))).ToList();

        List<MappedSalesFigures> finalSalesFigures = new List<MappedSalesFigures>();
        // mapped product list
        foreach(WineDetails wineDetail in wineDetails)
        {
            MappedSalesFigures obj = new MappedSalesFigures();
            obj.ProductId = wineDetail.Basic.ProductId;
            obj.ProductShortName = wineDetail.Basic.ProductShortName;
            obj.salesPerMonths = new List<SalesPerMonth>();
            foreach (SalesDetails details in salesDetails)
            {
                 foreach(var storeSale in details.StoreSales)
                {
                    foreach(var thatMonthSales in storeSale.Sales)
                    {
                        if(thatMonthSales.ProductId.Equals(obj.ProductId))
                        {
                            SalesPerMonth saleOfthatMonth = new SalesPerMonth();
                            saleOfthatMonth.SalesMonth = details.SalesMonth;
                            saleOfthatMonth.SalesQuantity = thatMonthSales.SalesQuantity;
                            saleOfthatMonth.SalesVolume = thatMonthSales.SalesVolume;
                            obj.salesPerMonths.Add(saleOfthatMonth);
                        }
                    }
                }
            }

            finalSalesFigures.Add(obj);
        }

       // Console.WriteLine(JsonConvert.SerializeObject(finalSalesFigures));
        //Log step in archeo
        LogStep logStep = new LogStep(JsonConvert.SerializeObject(finalSalesFigures), "Vinos", "Finished mapped list with sales figures from Halden", "Success", "mapProductwithSales");
        await logStep.LogToArcheo(logStep);
        //Logging errors
         logStep = new LogStep(" ", "Vinos", "Error", "Error", "errorlogs");
        await logStep.LogToArcheo(logStep);

    }

}
    



