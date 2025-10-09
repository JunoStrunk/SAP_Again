namespace SAP_Backend.Domain.Repositories
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SAP_Backend.Interfaces;
    using SAP_Backend.Models;
    using System.Collections.Generic;

    public class TeamRepository : ITeamRepository, IDisposable
    {
        private TeamContext _context;

        public TeamRepository(TeamContext context)
        {
            this._context = context;
        }

        public IEnumerable<Team> GetTeams()
        {
            return _context.Teams.ToList();
        }
        public async Task<List<Team>> GetTeamsAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public Team? GetTeamById(long id)
        {
            return _context.Teams.Find(id);
        }

        public async Task<ActionResult<Team?>> GetTeamByIdAsync(long id)
        {
            return await _context.Teams.FindAsync(id);
        }

        public void InsertTeam(Team team)
        {
            _context.Teams.Add(team);
        }

        public void DeleteTeam(long id)
        {
            Team? team = _context.Teams.Find(id);
            if(team != null)
            {
                _context.Teams.Remove(team);
            }
        }

        public void UpdateTeam(Team team)
        {
            _context.Entry(team).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
