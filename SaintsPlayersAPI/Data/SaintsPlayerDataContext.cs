using Microsoft.EntityFrameworkCore;
using SaintsPlayersAPI.Models;

namespace SaintsPlayersAPI.Data
{
    public class SaintsPlayerDataContext : DbContext
    {
        public SaintsPlayerDataContext(DbContextOptions<SaintsPlayerDataContext> options)
    : base(options)
        {
        }

        public DbSet<SaintsPlayer> SaintsPlayers { get; set; }
    }
}
