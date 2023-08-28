using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace VinmonopoletWineSalesFigures
{
	public class LogStep
	{
        HttpClient httpClient = new HttpClient();
        string archeoApi = "https://api.archeo.no/api/v1.1/Log/";
        string APIKEY = "EdxH4xwKBxXrE+8RUe9RtvKfq+bwpy6ARVOzkwqdHkfYO/DtX3Ccmge/TUDDXvwkM1Www3kTtmQFsx5jVBXChxZeIZWPRG6cfUuDJtI428w=";
        public string AuthGuid { get; set; }
        public string TransactionId { get; set; }
        public string TransactionType { get; set; }
        public string MessageType { get; set; }
        public string TransactionTag { get; set; }
        public DateTime Processed { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public byte[] BodyContent { get; set; }
        public string Status { get; set; }

        public LogStep(string content,string transactiontype,string description,string status,string messageType)
        {
            string uuidString = Guid.NewGuid().ToString();
            TransactionId = uuidString;
            TransactionType = transactiontype;
           // MessageType = messageType;
            Processed = DateTime.Now;
            Status = status;
            BodyContent = Encoding.UTF8.GetBytes(content);
            FileName = "VinomopoletAnaWineSalesFigures";
            Description = description;
            Sender = "Ana";
            Receiver = "Message Hub";
            TransactionTag = uuidString;
        }

        public async Task LogToArcheo(LogStep logStep)
        {
            httpClient.DefaultRequestHeaders.Add("APIKEY", APIKEY);
            List<LogStep> logSteps = new List<LogStep>();
            logSteps.Add(logStep);
            string jsonCont = JsonConvert.SerializeObject(logSteps);
            //Console.WriteLine(jsonCont);
            HttpContent content = new StringContent(jsonCont, Encoding.UTF8, "application/json");
            // Send the POST request
            HttpResponseMessage response = await httpClient.PostAsync(archeoApi, content);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("LogToArcheo Response:");
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine($"LogToArcheo Request failed with status code: {response.StatusCode}");
            }
            
        }



    }
}

