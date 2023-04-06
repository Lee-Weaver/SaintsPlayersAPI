using Microsoft.AspNetCore.Mvc;
using SaintsPlayersAPI.Models;

namespace SaintsPlayersAPI.Services.SaintsPlayerService
{
    public interface ISaintsPlayerService
    {
        Task<IEnumerable<SaintsPlayer>> GetAllPlayers();

        Task<SaintsPlayer> GetSinglePlayer(int id);

        Task<IEnumerable<SaintsPlayer>> AddPlayer([FromBody] SaintsPlayer player);

        Task<SaintsPlayer> UpdatePlayer(int id, [FromBody] SaintsPlayer request);

        Task<IEnumerable<SaintsPlayer>> DeletePlayer(int id, [FromBody] SaintsPlayer request);
    }
}
 