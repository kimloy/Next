using AutoMapper;
using Microsoft.EntityFrameworkCore;
using next_api.DbContexts;
using next_api.Entities;
using next_api.Models;
using System.Reflection.Metadata.Ecma335;

namespace next_api.Servies
{
    public class ParkService : IParkService
    {
        private readonly INextApiRepository _nextApiRepository;
        private readonly IMapper _mapper;


        public ParkService(NextApiContext nextApiContext, IMapper mapper, INextApiRepository nextApiRepository)
        {
            _nextApiRepository = nextApiRepository;
            _mapper = mapper;
        }


        public async Task<GameDocInfo?> GetGameDocInfo()
        {
            return await _nextApiRepository.GetGameDocInfo();
        }

        public async Task<IEnumerable<Game>> GetGames(string place_id)
        {
            var games = await _nextApiRepository.GetGames(place_id);

            if (games == null)
            {
                return Enumerable.Empty<Game>();
            }
            return games;
        }

        public async Task<GameDto?> GetGame(string gameID)
        {
            if (!await _nextApiRepository.GameExistAsync(gameID))
            {
                return null;
            }

            var gameEntity = await _nextApiRepository.GetGame(gameID);

            var gameDto = _mapper.Map<GameDto>(gameEntity);

            return gameDto;
        }

        //public async Task<PlaceDetailDto> CreatePlaceDto(PlaceDto placeDto)
        //{

        //}

        public async Task<GameDto?> CreateNewGameAsync(GameDto game, PlaceDetailDto park)
        {
            if(game.Game_ID != null && park.Result != null)
            {
                if (await _nextApiRepository.GameExistAsync(game.Game_ID))
                {
                    return null;
                }

                var newGameEntity = _mapper.Map<Game>(game);
                var parkEntity = _mapper.Map<Park>(park.Result);

                if (!await _nextApiRepository.ParkExistAsync(park.Result.Place_Id))
                {
                    await _nextApiRepository.CreatePark(parkEntity);
                }

                await _nextApiRepository.CreateNewGameAsync(newGameEntity, parkEntity);

                await _nextApiRepository.SaveChangesAsync();

                var createdGameEntity = _mapper.Map<Models.GameDto>(newGameEntity);

                return createdGameEntity;
            }
            return null;
        }

        public async Task<GameDto?> StartGameAsync(string game_ID)
        {
            var gameEntity = await _nextApiRepository.StartGame(game_ID);

            if (gameEntity != null)
            {
                await _nextApiRepository.SaveChangesAsync();
                var gameDto = _mapper.Map<GameDto>(gameEntity);

                return gameDto;
            }
            return null;
        }
    }
}
