using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaintsPlayersAPI.Data;
using SaintsPlayersAPI.Models;

namespace SaintsPlayersAPI.Services.SaintsPlayerService
{
    public class SaintsPlayerService : ISaintsPlayerService
    {

        private readonly SaintsPlayerDataContext _context;
        public SaintsPlayerService(SaintsPlayerDataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SaintsPlayer>> AddPlayer([FromBody] SaintsPlayer player)
        {
            _context.SaintsPlayers.Add(player);
            await _context.SaveChangesAsync();

            return await _context.SaintsPlayers.ToListAsync();
        }

        public async Task<IEnumerable<SaintsPlayer>> DeletePlayer(int id, [FromBody] SaintsPlayer request)
        {
            var player = await _context.SaintsPlayers.FindAsync(id);
            if (player == null)
            {
                return null;
            }
            _context.SaintsPlayers.Remove(player);

            await _context.SaveChangesAsync();

            return await _context.SaintsPlayers.ToListAsync();
        }

        public async Task<IEnumerable<SaintsPlayer>> GetAllPlayers()
        {
            var players = await _context.SaintsPlayers.ToListAsync();
            return players;
        }

        public async Task<SaintsPlayer> GetSinglePlayer(int id)
        {
            var player = await _context.SaintsPlayers.FindAsync(id);
            if (player == null)
            {
                return null;
            }
            return player;
        }

        public async Task<SaintsPlayer> UpdatePlayer(int id, [FromBody] SaintsPlayer request)
        {
            var player = await _context.SaintsPlayers.FindAsync(id);
            if (player == null)
            {
                return null;
            }

            player.Name = request.Name;
            player.Position = request.Position;
            player.Country = request.Country;
            player.Appearances = request.Appearances;
            player.Goals = request.Goals;

            await _context.SaveChangesAsync();

            return player;
        }
    }
}
