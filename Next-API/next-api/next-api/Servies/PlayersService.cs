using AutoMapper;
using next_api.Entities;
using next_api.Models;

namespace next_api.Servies
{
    public class PlayersService : IPlayersService
    {
        private readonly INextApiRepository _nextApiRepository;
        private readonly IMapper _mapper;
        public PlayersService(INextApiRepository nextApiRepository, IMapper mapper) 
        { 
            _nextApiRepository = nextApiRepository;
            _mapper = mapper;

        }

        public async Task<PlayerDto?> GetPlayerAsync(string Player_ID)
        {
            var playerEntity = await _nextApiRepository.GetPlayerAsync(Player_ID);
            
            if (playerEntity != null)
            {
                var playerDto = _mapper.Map<PlayerDto>(playerEntity);
                return playerDto;
            }

            return null;

        }
    }
}
