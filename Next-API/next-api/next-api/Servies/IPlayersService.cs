using next_api.Models;

namespace next_api.Servies
{
    public interface IPlayersService
    {
        Task<PlayerDto?> GetPlayerAsync(string Player_ID);
    }
}
