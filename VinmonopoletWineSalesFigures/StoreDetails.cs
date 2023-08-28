using System;
namespace VinmonopoletWineSalesFigures
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class StoreDetails
    {
        [JsonProperty("storeId")]
      
        public long StoreId { get; set; }

        [JsonProperty("storeName")]
        public string StoreName { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("telephone")]
        public string Telephone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("category")]
  
        public long Category { get; set; }

        [JsonProperty("profile")]
        public string Profile { get; set; }

        [JsonProperty("storeAssortment")]
        public string StoreAssortment { get; set; }

        [JsonProperty("openingHours")]
        public OpeningHours OpeningHours { get; set; }

        [JsonProperty("lastChanged")]
        public LastChanged LastChanged { get; set; }
    }

    public partial class Address
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("postalCode")]
      
        public long PostalCode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("gpsCoord")]
        public string GpsCoord { get; set; }

        [JsonProperty("globalLocationNumber")]
        public string GlobalLocationNumber { get; set; }

        [JsonProperty("organisationNumber")]
     
        public long OrganisationNumber { get; set; }
    }



    public partial class OpeningHours
    {
        [JsonProperty("regularHours")]
        public List<RegularHour> RegularHours { get; set; }

        [JsonProperty("exceptionHours")]
        public List<object> ExceptionHours { get; set; }
    }

    public partial class RegularHour
    {
        [JsonProperty("validFromDate")]
        public string ValidFromDate { get; set; }

        [JsonProperty("dayOfTheWeek")]
        public string DayOfTheWeek { get; set; }

        [JsonProperty("openingTime")]
        public string OpeningTime { get; set; }

        [JsonProperty("closingTime")]
        public string ClosingTime { get; set; }

        [JsonProperty("closed")]
        public bool Closed { get; set; }
    }

   
 
}

