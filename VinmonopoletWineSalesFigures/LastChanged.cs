using System;
using Newtonsoft.Json;

namespace VinmonopoletWineSalesFigures
{
	public class LastChanged
	{
		public LastChanged()
		{
		}
        [JsonProperty("date")]
        public DateTimeOffset saleDate { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset saleTime { get; set; }
    }
}

