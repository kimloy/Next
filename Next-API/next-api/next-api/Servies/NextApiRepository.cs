using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using next_api.DbContexts;
using next_api.Entities;
using next_api.Models;
using System.Runtime.CompilerServices;


namespace next_api.Servies
{
    public class NextApiRepository : INextApiRepository
    {
        private readonly NextApiContext _context; 

        public NextApiRepository(NextApiContext context)
        {
           this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //Player actions

        public async Task<Player?> GetPlayerAsync(string playerID)
        {
            return await _context.Player.Where(p => p.Player_ID == playerID).FirstOrDefaultAsync();
        }

        public async Task<bool> PlayerExist(string playerId)
        {
            return await _context.Player.AnyAsync(p => p.Player_ID == playerId);
        }

        public async Task CreatePlayer (Player player)
        {
            if(!await this.PlayerExist(player.Player_ID))
            {
                _context.Player.Add(player);
            }
        }

        //Game doc actions

        public async Task<GameDocInfo?> GetGameDocInfo()
        {
            return await _context.GameDocInfos.Include(gD => gD.Sports_List)
               .Where(g => g.Id == 1).FirstOrDefaultAsync();
        }

        //Park actions
        public async Task<Park?>GetPark(string place_id)
        {
            return await _context.Park.Where(p => p.Place_Id == place_id).FirstOrDefaultAsync();    
        }

        public async Task<bool> ParkExistAsync(string place_id)
        {
            return await _context.Park.AnyAsync(p => p.Place_Id == place_id);
        }


        public async Task CreatePark(Park park)
        {
            var doesParkExist = await ParkExistAsync(park.Place_Id);
            if(!doesParkExist)
            {
                _context.Park.Add(park);
                await SaveChangesAsync();
            }
        }

        //Games action
        public async Task<IEnumerable<Game>> GetGames(string place_id)
        {
            var collection = _context.Game as IQueryable<Game>;

            var collectionToReturn = await collection
                .Select(g => g)
                .Where(g => g.Place_id == place_id)
                .OrderBy(g => g.Name)
                .ToListAsync();
            return collectionToReturn;
        }

        public async Task<Game?> GetGame(string gameID)
        {
            return await _context.Game.Where(g => g.Game_ID == gameID).FirstOrDefaultAsync();
        }


        public async Task<bool> GameExistAsync(string gameID)
        {
            return await _context.Game.AnyAsync(g => g.Game_ID == gameID);
        }

        public async Task CreateNewGameAsync(Game game, Park park)
        {
            if(park.Place_Id  != null)
            {
                var doesParkExist = await ParkExistAsync(park.Place_Id);

                if (!doesParkExist)
                {
                   await CreatePark(park);
                }
            }

            var doesGameExist = await GameExistAsync(game.Game_ID);

            if (!doesGameExist)
            {
                var currPark = await GetPark(park.Place_Id);
                _context.Game.Add(game);
                currPark.Games.Add(game);

            }
        }

        public async Task<Game?> StartGame(string game_ID)
        {
            var game = await GetGame(game_ID);

            if(game != null)
            {
                game.Active = true;
                return game;
            }
            return null;
        }

        // Save to database

        public async Task<bool> SaveChangesAsync()
        {
            var result = (await _context.SaveChangesAsync() >= 0);
            return result;
        }
    }
}
