using AutoMapper;
using next_api.Entities;

using Microsoft.AspNetCore.Mvc;
using next_api.Servies;
using next_api.Models;

namespace next_api.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayersController : ControllerBase
    {
       private readonly IPlayersService _playersService;
       public PlayersController(IPlayersService playersService)
        {
            _playersService = playersService;  
        }

        [HttpGet("getPlayer/{Player_ID}")]
        public async Task<ActionResult<PlayerDto>> GetPlayer(string Player_ID)
        {
            var playerDto = await _playersService.GetPlayerAsync(Player_ID);

            if(playerDto != null)
            {
                return Ok(playerDto);
            }
            return NotFound();
        }

    }
}
