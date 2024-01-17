using DigitalMenu.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DigitalMenu.DataServices
{
    public class RestaurantDataService : IRestaurantDataService
    {
        private HttpClient _httpClient;
        private string _baseAddress;
        private string _apiVersion;
        private string _baseUrl;
        private string _protocol;
        private JsonSerializerOptions _jsonSerializerOptions;

        public RestaurantDataService()
        {
            _httpClient = new HttpClient();
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2:8000" : "localhost:8000";
            _apiVersion = "v1";
            _baseUrl = "api";
            _protocol = "http";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public string Address
        {
            get
            {
                return $"{_protocol}://{_baseAddress}/{_baseUrl}/{_apiVersion}/";
            }
        }
        public async Task<List<Restaurant>> SearchAsync(string name)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No Internet Access");
                return restaurants;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{Address}/search");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    restaurants = JsonSerializer.Deserialize<List<Restaurant>>(content, _jsonSerializerOptions);
                } else
                {
                    Debug.WriteLine($"Error status code:{response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception:{ex.Message}");
            }

            return restaurants;
        }
    }
}
