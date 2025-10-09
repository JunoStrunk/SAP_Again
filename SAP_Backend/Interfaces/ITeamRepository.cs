using Microsoft.AspNetCore.Mvc;
using SAP_Backend.Models;

namespace SAP_Backend.Interfaces
{
    public interface ITeamRepository
    {
        public IEnumerable<Team> GetTeams();
        public Task<List<Team>> GetTeamsAsync();
        public Team? GetTeamById(long id);
        public Task<ActionResult<Team?>> GetTeamByIdAsync(long id);
        public void InsertTeam(Team team);
        public void DeleteTeam(long id);
        public void UpdateTeam(Team team);
        public void Save();
        public Task<int> SaveAsync();
    }
}
