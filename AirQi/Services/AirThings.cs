using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AirQi
***REMOVED***
    public class AirThings 
    ***REMOVED***
        private HttpClient _client = new HttpClient();
        private string url = "https://airthings.azure-api.net/api/Devices";

        public void ExecuteWorker()
        ***REMOVED***
            throw new NotImplementedException();
       ***REMOVED***

        public async Task ExecuteWorkerAsync()
        ***REMOVED***
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "94fceb37077f44eb8cefa7d9fe6a4d1e");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            ***REMOVED***
                Console.WriteLine(responseBody);
           ***REMOVED***
            else
            ***REMOVED***
                Console.WriteLine("The website is down. Status code ***REMOVED***StatusCode***REMOVED***", response.StatusCode);
           ***REMOVED***
       ***REMOVED***
   ***REMOVED***
***REMOVED***