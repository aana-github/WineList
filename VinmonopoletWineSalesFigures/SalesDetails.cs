using System;

namespace VinmonopoletWineSalesFigures
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SalesDetails
    {
        [JsonProperty("salesMonth")]
        public string SalesMonth { get; set; }

        [JsonProperty("storeSales")]
        public List<StoreSale> StoreSales { get; set; }
    }

    public partial class StoreSale
    {
        [JsonProperty("storeId")]
        
        public long StoreId { get; set; }

        [JsonProperty("sales")]
        public List<Sale> Sales { get; set; }
    }

    public partial class Sale
    {
        [JsonProperty("productId")]
    
        public long ProductId { get; set; }

        [JsonProperty("salesVolume")]
        public double SalesVolume { get; set; }

        [JsonProperty("salesQuantity")]
        public long SalesQuantity { get; set; }

        [JsonProperty("lastChanged")]
        public LastChanged LastChanged { get; set; }

       
    }


  
    
}

