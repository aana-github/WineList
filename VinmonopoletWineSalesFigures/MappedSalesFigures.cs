using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VinmonopoletWineSalesFigures;

namespace VinmonopoletWineSalesFigures
{
	public class MappedSalesFigures
	{
		public MappedSalesFigures()
		{
		}
        [JsonProperty("productId")]

        public long ProductId { get; set; }

        [JsonProperty("productShortName")]
        public string ProductShortName { get; set; }

        public List<SalesPerMonth> salesPerMonths { get; set; }

    }
}

