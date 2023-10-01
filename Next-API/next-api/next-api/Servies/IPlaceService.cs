using next_api.Entities;
using next_api.Models;

namespace next_api.Servies
{
    public interface IPlaceService
    {
        Task<PlacesNearbySearchDto?> GetNearbyPlacesAsync(double lat, double lon);
        Task<GeocodingDto?> GetGeolocationAsync(string zipcode);
        
        Task<PlaceDetailDto?> GetPlaceDetailAsync(string place_id);
    }
}
