using System.ComponentModel;
using System.Xml.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Team> teams = new();
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                string teamName = cmdArgs[1];

                try
                {
                    switch (cmdType)
                    {
                        case "Team":
                            CreateTeam(teamName, teams);
                            break;
                        case "Add":
                            string playerName = cmdArgs[2];
                            int endurance = int.Parse(cmdArgs[3]);
                            int sprint = int.Parse(cmdArgs[4]);
                            int dribble = int.Parse(cmdArgs[5]);
                            int passing = int.Parse(cmdArgs[6]);
                            int shooting = int.Parse(cmdArgs[7]);
                            AddPlayer(teamName, playerName, endurance, sprint, dribble, passing, shooting, teams);
                            break;
                        case "Remove":
                            string player = cmdArgs[2];
                            RemovePlayer(teamName, player, teams);
                            break;
                        case "Rating":
                            RatingTeam(teamName, teams);
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }


            }

        }



        private static void CreateTeam(string teamName, List<Team> teams)
        {
            Team team = new(teamName);
            teams.Add(team);
        }
        private static void AddPlayer(string teamName, string playerName, int endurance, int sprint, int dribble, int passing, int shooting, List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                Console.WriteLine($"Team {teamName} does not exist.");

                return;
            }

            Player player = new(playerName, endurance, sprint, dribble, passing, shooting);
            team.AddPlayer(player);
        }
        private static void RemovePlayer(string teamName, string player, List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                Console.WriteLine($"Team {teamName} does not exist.");

                return;
            }

            team.RemovePlayer(player);
        }
        private static void RatingTeam(string teamName, List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                Console.WriteLine($"Team {teamName} does not exist.");

                return;
            }

            Console.WriteLine($"{teamName} - {team.Rating:f0}");
        }
    }
}

