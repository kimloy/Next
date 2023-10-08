using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NextBFF.Controller
{
    [Route("api/park")]
    public class ParkController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ParkController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("getgames/{place_id}")]
        public async Task<ActionResult> GetGames(
            string place_id)
        {
            // create HTTP client
            var client = _httpClientFactory.CreateClient();

            // get current user access token and set it on HttpClient
            var token = await HttpContext.GetUserAccessTokenAsync();

            if (token.AccessToken == null)
            {
                return NotFound();
            }

            client.SetBearerToken(token.AccessToken);

            var response = await client.GetAsync($"https://localhost:7151/api/park/getgames/{place_id}");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return Unauthorized();
            }

            var respString = await response.Content.ReadAsStringAsync();

            return Content(respString, "application/json");
        }

        [HttpGet("getDocInfo")]
        public async Task<ActionResult> GetParksDocInfoAsync()
        {
            // create HTTP client
            var client = _httpClientFactory.CreateClient();

            // get current user access token and set it on HttpClient
            var token = await HttpContext.GetUserAccessTokenAsync();

            if (token.AccessToken == null)
            {
                return NotFound();
            }

            client.SetBearerToken(token.AccessToken);

            var response = await client.GetAsync($"https://localhost:7151/api/park/getDocInfo");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return Unauthorized();
            }
            var respString = await response.Content.ReadAsStringAsync();

            return Content(respString, "application/json");

        }

        [HttpGet("detail/{place_id}")]
        public async Task<IActionResult> GetPlaceDetailAsync(string place_id)
        {
            // create HTTP client
            var client = _httpClientFactory.CreateClient();

            // get current user access token and set it on HttpClient
            var token = await HttpContext.GetUserAccessTokenAsync();

            if (token.AccessToken == null)
            {
                return NotFound();
            }

            client.SetBearerToken(token.AccessToken);

            var response = await client.GetAsync($"https://localhost:7151/api/places/detail/{place_id}");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return Unauthorized();
            }

            var respString = await response.Content.ReadAsStringAsync();

            return Content(respString, "application/json");
        }

        [HttpGet("getGame/{gameID}")]
        public async Task<ActionResult> GetGame(string gameID)
        {
            // create HTTP client
            var client = _httpClientFactory.CreateClient();

            // get current user access token and set it on HttpClient
            var token = await HttpContext.GetUserAccessTokenAsync();

            if (token.AccessToken == null)
            {
                return NotFound();
            }

            client.SetBearerToken(token.AccessToken);

            var response = await client.GetAsync($"https://localhost:7151/api/park/getGame/{gameID}");

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return Unauthorized();
            }

            var respString = await response.Content.ReadAsStringAsync();

            return Content(respString, "application/json");
        }

        [HttpPost("CreateNewGame")]
        public async Task<ActionResult> CreateNewGame([FromBody] object createNewGame)
        {
            // create HTTP client
            var client = _httpClientFactory.CreateClient();

            // get current user access token and set it on HttpClient
            var token = await HttpContext.GetUserAccessTokenAsync();

            if (token.AccessToken == null)
            {
                return NotFound();
            }

            client.SetBearerToken(token.AccessToken);

            var response = await client.PostAsJsonAsync($"https://localhost:7151/api/park/CreateNewGame", createNewGame);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return Unauthorized();
            }

            var respString = await response.Content.ReadAsStringAsync();

            return Content(respString, "application/json");
        }

        [HttpPost("startGame")]
        public async Task<ActionResult> StartGame([FromBody] object gameDto)
        {
            // create HTTP client
            var client = _httpClientFactory.CreateClient();

            // get current user access token and set it on HttpClient
            var token = await HttpContext.GetUserAccessTokenAsync();

            if (token.AccessToken == null)
            {
                return NotFound();
            }

            client.SetBearerToken(token.AccessToken);

            var response = await client.PostAsJsonAsync($"https://localhost:7151/api/park/startGame", gameDto);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return Unauthorized();
            }

            var respString = await response.Content.ReadAsStringAsync();

            return Content(respString, "application/json");
        }
    }
}
