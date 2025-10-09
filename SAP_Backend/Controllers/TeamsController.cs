using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAP_Backend.Models;
using SAP_Backend.Domain.DTO;
using SAP_Backend.Interfaces;
using SAP_Backend.Domain.Repositories;

namespace SAP_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;

        public TeamsController(TeamContext context)
        {
            _teamRepository = new TeamRepository(context);
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            return await _teamRepository.GetTeamsAsync();
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team?>> GetTeam(long id)
        {
            var team = await _teamRepository.GetTeamByIdAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return team;
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(long id, Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            _teamRepository.UpdateTeam(team);

            try
            {
                await _teamRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            _teamRepository.InsertTeam(team);
            await _teamRepository.SaveAsync();

            return CreatedAtAction("GetTeam", new { id = team.Id }, team);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(long id)
        {
            var team = await _teamRepository.GetTeamByIdAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            _teamRepository.DeleteTeam(id);
            await _teamRepository.SaveAsync();

            return NoContent();
        }

        private bool TeamExists(long id)
        {
            Team? team = _teamRepository.GetTeamById(id);
            
            if(team != null)
            {
                return true;
            }

            return false;
        }

        private static TeamDTO TeamToDTO(Team team)
        {
            return new TeamDTO
            {
                Round = team.Round,
                Wins = team.Wins,
                Members = team.PetIds
            };
        }
    }
}
