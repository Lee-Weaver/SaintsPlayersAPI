using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaintsPlayersAPI.Models;
using SaintsPlayersAPI.Services.SaintsPlayerService;

namespace SaintsPlayersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaintsPlayerControllerv2 : ControllerBase
    {
        private readonly ISaintsPlayerService _saintsPlayerService;
        public SaintsPlayerControllerv2(ISaintsPlayerService saintsPlayerService)
        {
            _saintsPlayerService = saintsPlayerService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SaintsPlayer>>> GetAllPlayers()
        {
            var result = await _saintsPlayerService.GetAllPlayers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaintsPlayer>> GetSinglePlayer(int id)
        {
            var result = await _saintsPlayerService.GetSinglePlayer(id);
            if (result == null)
            {
                return NotFound("No player found with this id");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SaintsPlayer>>> AddPlayer([FromBody]SaintsPlayer player)
        {
            var result = await _saintsPlayerService.AddPlayer(player);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SaintsPlayer>> UpdatePlayer(int id, [FromBody]SaintsPlayer request)
        {
            var result = await _saintsPlayerService.UpdatePlayer(id, request);
            if (result == null)
            {
                return NotFound("Not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SaintsPlayer>>> DeletePlayer(int id, [FromBody]SaintsPlayer request)
        {
            var result = await _saintsPlayerService.DeletePlayer(id, request);
            if (result == null)
            {
                return NotFound("Not found");
            }
            return Ok(result);
        }
    }
        
    
}
