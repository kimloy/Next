using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Nodes;

namespace NextBFF.Controller
{
    [Route("/api/places")]
    public class PlacesController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PlacesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("geocoding/{zipcode}")]
        public async Task<IActionResult> Get(string zipcode)
        {
            // create HTTP client
            var client = _httpClientFactory.CreateClient();

            // get current user access token and set it on HttpClient
            var token = await HttpContext.GetUserAccessTokenAsync();

            if(token.AccessToken == null)
            {
                return NotFound();
            }

            client.SetBearerToken(token.AccessToken);


            // call remote API
            var response = await client.GetAsync($"https://localhost:7151/api/places/geocoding/{zipcode}");

            var respString = await response.Content.ReadAsStringAsync();

            return Content(respString, "application/json");


            // maybe process response and return to frontend
            
        }
    }
}
