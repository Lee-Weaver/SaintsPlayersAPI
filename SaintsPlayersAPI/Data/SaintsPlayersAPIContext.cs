using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaintsPlayersAPI.Models;

namespace SaintsPlayersAPI.Data
{
    public class SaintsPlayersAPIContext : DbContext
    {
        public SaintsPlayersAPIContext (DbContextOptions<SaintsPlayersAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SaintsPlayersAPI.Models.SaintsPlayer> SaintsPlayer { get; set; } = default!;
    }
}
