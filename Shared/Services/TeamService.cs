using Microsoft.Extensions.Configuration;
using Project.FootballTrick.Shared.Entities;
using Project.FootballTrick.Shared.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Project.FootballTrick.Shared.Services
{
    public class TeamService : ITeamService
    {        
        string connectionString = string.Empty;
        private readonly IConfiguration configuration;     
        public TeamService(IConfiguration _configuration)
        {
            connectionString = _configuration.GetConnectionString("FootballTrickDatabase");
        }

        public IEnumerable<Team> GetAllTeams()
        {
            List<Team> listTeams = new List<Team>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_GetAllTeams", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Team team = new Team();
                    team.TeamId = Convert.ToInt32(rdr["TeamId"]);
                    team.Name = rdr["Name"].ToString();
                    team.CreationDate = Convert.ToDateTime(rdr["CreationDate"].ToString());
                 
                    listTeams.Add(team);
                }
                con.Close();
            }

            return listTeams;
        }

        public void AddTeam(Team team)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_AddNewTeam", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", team.Name);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateTeam(Team team)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_UpdateTeam", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TeamId", team.TeamId);
                cmd.Parameters.AddWithValue("@Name", team.Name);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteTeam(int? teamId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Sp_DeleteTeam", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeamId", teamId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
 }
