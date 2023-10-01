using Microsoft.AspNetCore.Mvc;
using next_api.Servies;

namespace next_api.Controllers
{

    [ApiController]
    [Route("api/places")]
    public class PlacesController:ControllerBase
    {
        private IPlaceService _placesService;

        public PlacesController(IPlaceService placesService) 
        { 
            _placesService = placesService ?? throw new ArgumentNullException(nameof(_placesService));
        }

        [HttpGet("geocoding/{zipcode}")]
        public ActionResult GetGeolocation(string zipcode)
        {
            var result = _placesService.GetGeolocationAsync(zipcode).ConfigureAwait(false).GetAwaiter().GetResult(); ;

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("nearby/{lat}/{lng}")]
        public ActionResult GetPlacesNearby(string lat, string lng)
        {
            var newLat = Convert.ToDouble(lat);
            var newLng = Convert.ToDouble(lng);
            var result = _placesService.GetNearbyPlacesAsync(newLat, newLng).ConfigureAwait(false).GetAwaiter().GetResult();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("detail/{place_id}")]
        public ActionResult GetPlaceDetailAsync(string place_id)
        {
            var result = _placesService.GetPlaceDetailAsync(place_id).ConfigureAwait(false).GetAwaiter().GetResult(); ;

            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
