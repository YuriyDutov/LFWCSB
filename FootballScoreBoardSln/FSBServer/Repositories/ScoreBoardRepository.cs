using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSBServer.Entities;

namespace FSBServer.Repositories
{
    public class ScoreBoardRepository: IScoreBoardRepository
    {
        public List<FootballMatch> Get()
        {
            return new List<FootballMatch>
            {
                new FootballMatch
                {
                    Id = 1,
                    HomeTeam = "Mexico",
                    AwayTeam = "Canada",
                    HomeTeamScore = 0,
                    AwayTeamScore = 5,
                    InProgress = true,
                    TotalScore = 5
                },
                new FootballMatch
                {
                    Id = 2,
                    HomeTeam = "Spain",
                    AwayTeam = "Brazil",
                    HomeTeamScore = 10,
                    AwayTeamScore = 2,
                    InProgress = true,
                    TotalScore = 12
                },
                new FootballMatch
                {
                    Id = 3,
                    HomeTeam = "Germany",
                    AwayTeam = "France",
                    HomeTeamScore = 2,
                    AwayTeamScore = 2,
                    InProgress = true,
                    TotalScore = 4
                },
                new FootballMatch
                {
                    Id = 4,
                    HomeTeam = "Uruguay",
                    AwayTeam = "Italy",
                    HomeTeamScore = 6,
                    AwayTeamScore = 6,
                    InProgress = true,
                    TotalScore = 12
                },
                new FootballMatch
                {
                    Id = 5,
                    HomeTeam = "Argentina",
                    AwayTeam = "Australia",
                    HomeTeamScore = 3,
                    AwayTeamScore = 1,
                    InProgress = true,
                    TotalScore = 4
                }
            };
        }
    }
}
