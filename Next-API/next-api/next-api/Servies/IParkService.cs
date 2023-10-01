using next_api.Entities;
using next_api.Models;

namespace next_api.Servies
{
    public interface IParkService
    {
        Task<GameDocInfo?> GetGameDocInfo();

        Task<IEnumerable<GameDto>> GetGames(string place_id);

        Task<GameDto?> GetGame(string gameID);

        Task<GameDto?> CreateNewGameAsync(GameDto game, PlaceDetailDto park);

        Task<GameDto?> StartGameAsync(string game_Id);
    }
}
