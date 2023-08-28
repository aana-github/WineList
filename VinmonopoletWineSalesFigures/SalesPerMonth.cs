using System;
using Newtonsoft.Json;

namespace VinmonopoletWineSalesFigures
{
	public class SalesPerMonth
	{
		public SalesPerMonth()
		{
		}
        [JsonProperty("salesMonth")]
        public string SalesMonth { get; set; }
        [JsonProperty("salesVolume")]
        public double SalesVolume { get; set; }
        [JsonProperty("salesQuantity")]
        public long SalesQuantity { get; set; }
    }
}

