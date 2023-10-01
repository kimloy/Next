using Azure;
using Newtonsoft.Json;
using next_api.Entities;
using next_api.Models;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;

namespace next_api.Servies
{
    public class PlacesService: IPlaceService
    {

        private static readonly HttpClient Client = new HttpClient();
        private readonly string _API_KEY = string.Empty;

        public PlacesService(IConfiguration configuration) 
        {
            _API_KEY = configuration["GoogleMapsAPI:KEY"];
        }


        public async Task<PlacesNearbySearchDto?> GetNearbyPlacesAsync( double lat, double lng)
        {
            var content = await Client
                .GetStringAsync($"https://maps.googleapis.com/maps/api/place/nearbysearch/json?key={_API_KEY}" +
                    $"&keyword=playground" +
                    $"&location={lat}%2c{lng}" +
                    $"&radius=20000" +
                    $"&type=parks").ConfigureAwait(false);

            var test = await Client
                .GetStringAsync($"https://maps.googleapis.com/maps/api/place/details/json?place_id=ChIJHyKi3jdhwokRWjmf8zkQ7Hg&fields=name,photos&key={_API_KEY}").ConfigureAwait(false);

            Console.WriteLine(test);

            var result = JsonConvert.DeserializeObject<PlacesNearbySearchDto>(content);
            return result;
        }

        public async Task<PlaceDetailDto?> GetPlaceDetailAsync(string place_id)
        {
            var content = await Client
                .GetStringAsync($"https://maps.googleapis.com/maps/api/place/details/json?place_id={place_id}" +
                $"&key={_API_KEY}").ConfigureAwait(false);

            var result = JsonConvert.DeserializeObject<PlaceDetailDto>(content);
            return result;
        }

        public async Task<GeocodingDto?> GetGeolocationAsync(string zipcode)
        {
            var content = await Client.GetStringAsync($"https://maps.googleapis.com/maps/api/geocode/json?address={zipcode}&key={_API_KEY}").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<GeocodingDto>(content);
            return result;
        }
    }
}
