using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using next_api.Entities;
using next_api.Models;
using next_api.Servies;
using System.Reflection.Metadata.Ecma335;

namespace next_api.Controllers
{
    [ApiController]
    [Route("api/park")]
    public class ParkController : ControllerBase
    {
        private IParkService _parkService;
        private readonly IMapper _mapper;

        public ParkController(IParkService parkService, IMapper mapper, INextApiRepository nextApiRepository)
        {
            _parkService = parkService;
            _mapper = mapper;
        }

        [HttpGet("getgames/{place_id}")]
        public async Task<ActionResult<IEnumerable<GameDto>>>GetGames(
            string place_id)
        {
            var games = await _parkService.GetGames(place_id);

            if(games == null)
            {
                return NotFound();
            }
            return Ok(games);
        }

        [HttpGet("getDocInfo")]
        public async Task<ActionResult> GetParksDocInfoAsync ()
        {
            var gameDoc = await _parkService.GetGameDocInfo();
            if(gameDoc != null)
            {
                var docDto = this._mapper.Map<GameDocInfoDto>(gameDoc);
                return Ok(docDto);
            }
            return NotFound();
           
        }

        [HttpGet("getGame/{gameID}")]
        public async Task<ActionResult<GameDto>> GetGame(string gameID)
        {
           var gameDto = await _parkService.GetGame(gameID);

           if(gameDto == null)
           {
                return NotFound();
           }

            return Ok(gameDto);
        }

        [IgnoreAntiforgeryToken]
        [HttpPost("CreateNewGame")]
        public async Task<ActionResult> CreateNewGame([FromBody] CreateNewGameDto createNewGame)
        {
            if (createNewGame.Game != null && createNewGame.placeDetail != null)
            {
                var createdGame = await _parkService.CreateNewGameAsync(createNewGame.Game, createNewGame.placeDetail);

                if (createdGame != null)
                {
                    return Ok(createdGame);
                }
                return NotFound();
              
            }
            return NotFound();
        }

        [HttpPost("startGame")]
        public async Task<ActionResult> StartGame([FromBody] GameDto gameDto)
        {
            if (gameDto != null && gameDto.Game_ID != null)
            {
                var game = await _parkService.StartGameAsync(gameDto.Game_ID);
                return Ok(game);

            }
            return NotFound();
        }
    }


   
}
