namespace VinmonopoletWineSalesFigures
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class WineDetails
    {
        [JsonProperty("basic")]
        public Basic Basic { get; set; }

        [JsonProperty("lastChanged")]
        public LastChanged LastChanged { get; set; }
    }

    public partial class Basic
    {
        [JsonProperty("productId")]
        public long ProductId { get; set; }

        [JsonProperty("productShortName")]
        public string ProductShortName { get; set; }
    }

    
}
