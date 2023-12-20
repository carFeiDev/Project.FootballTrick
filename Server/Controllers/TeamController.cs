using Microsoft.AspNetCore.Mvc;
using Project.FootballTrick.Shared.Entities;
using Project.FootballTrick.Shared.Interfaces;

namespace Project.FootballTrick.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _iTeamService;
        public TeamController(ITeamService iTeamService) {

            this._iTeamService = iTeamService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Team> teams = new List<Team>();

            teams = _iTeamService.GetAllTeams().ToList();

            return Ok(teams);
        }

        [HttpPost]
        [Route("post-team")]
        public async Task<IActionResult> AddNewTeam(Team team)
        {
            try
            {
                _iTeamService.AddTeam(team);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{teamId}")]
        public async Task<IActionResult> DeleteTeam(int teamId)
        {
           
            _iTeamService.DeleteTeam(teamId);

            return Ok();
        }


        [HttpPost("update-team")]
        public async Task<IActionResult> UpdateTeam(Team team)
        {
            try
            {
                _iTeamService.UpdateTeam(team);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}