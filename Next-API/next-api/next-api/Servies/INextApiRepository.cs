using next_api.Entities;
using next_api.Models;

namespace next_api.Servies
{
   public interface INextApiRepository
    {
        Task<IEnumerable<Game>> GetGames(string parkID);

        Task<Game?> GetGame(string gameID);

        Task<bool> GameExistAsync(string gameID);

        Task<GameDocInfo?> GetGameDocInfo();

        Task<Park?> GetPark(string parkID);

        Task<bool> ParkExistAsync(string parkID);

        Task CreatePark(Park park);

        Task<Game?> StartGame(string game_ID);

        Task CreateNewGameAsync(Game game, Park park);

        Task<bool> SaveChangesAsync();

    }
}
