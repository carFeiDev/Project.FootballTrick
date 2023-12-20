using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.FootballTrick.Shared.Entities;

namespace Project.FootballTrick.Shared.Interfaces
{
    public interface ITeamService
    {
        public IEnumerable<Team> GetAllTeams();
        public void AddTeam(Team team);
        public void UpdateTeam(Team team);
        public void DeleteTeam(int? teamId);
    }
}