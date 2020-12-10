using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AirQi.Models.Core;
using AirQi.Repository;
using AirQi.Services;
using AirQi.Settings;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AirQi
{
    public class PullOpenAqi : WorkerService
    {
        private HttpClient _client;
        public PullOpenAqi(IMongoDataRepository<Station> repository, IWorkerSettings settings) : base(repository, settings)
        {
            this.Repository = repository;
            this.Settings = settings;
            this.Client = new HttpClient();
        }

        public HttpClient Client { get => _client; set => _client = value; }

        public override async Task PullDataAsync()
        {
            // Gets headers which should be sent in each request.
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await Client.GetAsync("https://api.openaq.org/v1/latest");

            // Throws an Exception if the HttpResponseMessage.IsSuccessStatusCode property for HTTP response is 'false'. 
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            
            dynamic json = JsonConvert.DeserializeObject(result);
            
            foreach (var s in json.results)
            {

                if (s.coordinates != null)
                {
                
                Station station = new Station();
                station.Location = s.location.ToString();
                station.City = s.city.ToString();
                station.Country = s.country.ToString();
                
                Coordinates coordinates = new Coordinates();
                coordinates.Latitude = Convert.ToDouble(s.coordinates.latitude);
                coordinates.Longitude = Convert.ToDouble(s.coordinates.longitude);
                station.Coordinates = coordinates;
                station.CreatedAt = DateTime.UtcNow;
                station.UpdatedAt = DateTime.UtcNow;
                station.Aqi = 0;

                    List<Measurement> measurementsCollection = new List<Measurement>();

                    foreach(var m in s.measurements)
                    {
                        Measurement measurement = new Measurement();
                        measurement.Parameter = Convert.ToString(m.parameter);
                        measurement.Value = Convert.ToDouble(m.value);
                        measurement.LastUpdated = Convert.ToString(m.lastUpdated);
                        measurement.Unit = Convert.ToString(m.unit);
                        measurement.SourceName = Convert.ToString(m.sourceName);

                        measurement.Coordinates = coordinates;
                        measurement.CreatedAt = DateTime.UtcNow;
                        measurement.UpdatedAt = DateTime.UtcNow;

                        if(Convert.ToString(m.parameter) == "pm10")
                        {
                            station.Aqi = Convert.ToDouble(m.value);
                        } 
                        else if(Convert.ToString(m.parameter) == "pm25" && station.Aqi == 0)
                        {
                            station.Aqi = Convert.ToDouble(m.value);
                        }

                        measurementsCollection.Add(measurement);
                    }

                    station.Measurements = measurementsCollection;
                    
                    // Save the new Station in the repository only when there is a location
                    System.Console.WriteLine($"OpenAqi saved {station.Location} station in {station.City}, {station.Country}");
                    Repository.CreateObject(station);
                }

            }
           
        }
    }
}