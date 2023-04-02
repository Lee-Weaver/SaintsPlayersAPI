using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaintsPlayersAPI.Data;
using SaintsPlayersAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SaintsPlayersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaintsPlayersController : ControllerBase
    {
        private readonly SaintsPlayersAPIContext _context;

        public SaintsPlayersController(SaintsPlayersAPIContext context)
        {
            _context = context;
        }

        // GET: api/SaintsPlayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaintsPlayer>>> GetSaintsPlayer()
        {
          if (_context.SaintsPlayer == null)
          {
              return NotFound();
          }
            _context.SaintsPlayer.OrderByDescending(e
                  => e.Appearances);
            return await _context.SaintsPlayer.ToListAsync();
        }

        // GET: api/SaintsPlayers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaintsPlayer>> GetSaintsPlayer(int id)
        {
          if (_context.SaintsPlayer == null)
          {
              return NotFound();
          }
            var saintsPlayer = await _context.SaintsPlayer.FindAsync(id);

            if (saintsPlayer == null)
            {
                return NotFound();
            }
            return saintsPlayer;
        }

        [HttpGet("Country/{country}")]
        public async Task<ActionResult<IEnumerable<SaintsPlayer>>> SearchCountry(string country)
        {
            if (!string.IsNullOrEmpty(country))
            {
                _context.SaintsPlayer.Where (e => e.Country.Contains(country));
            }
            return await _context.SaintsPlayer.ToListAsync();
        }

        [HttpGet("Position/{position}")]
        public async Task<ActionResult<IEnumerable<SaintsPlayer>>> SearchPosition(string position)
        {
            if (!string.IsNullOrEmpty(position))
            {
                _context.SaintsPlayer.Where(e => e.Position.Contains(position));
            }
            return await _context.SaintsPlayer.ToListAsync();
        }

    }
}
