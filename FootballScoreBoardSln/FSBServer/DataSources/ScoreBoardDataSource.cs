using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSBServer.Entities;

namespace FSBServer.DataSources
{
    public class ScoreBoardDataSource: IDataSource
    {
        private static List<FootballMatch> ListOfFootballMatches { get; set; }
        private static ScoreBoardDataSource _dataSource = null;

        public static ScoreBoardDataSource GetDataSource()
        {
            if (_dataSource == null)
            {
                _dataSource = new ScoreBoardDataSource();
                CreateData();
            }

            return _dataSource;
        }

        public List<FootballMatch> GetData()
        {
            return ListOfFootballMatches;
        }
        
        public bool Add(FootballMatch footballMatch)
        { 
            ListOfFootballMatches.Add(footballMatch);
            return true;
        }

        public bool Update(FootballMatch footballMatch)
        { 
            ListOfFootballMatches.Where(x=> x.Id  == footballMatch.Id).ToList().ForEach(i =>
            {
                i.InProgress = footballMatch.InProgress;
                i.AwayTeamScore = footballMatch.AwayTeamScore;
                i.HomeTeamScore = footballMatch.HomeTeamScore;
                i.TotalScore = footballMatch.TotalScore;
            });
            return true;
        }

        public bool Delete(int id)
        { 
            ListOfFootballMatches.Remove(ListOfFootballMatches.Find(x => x.Id == id));
            return true;
        }
        
        private static void CreateData()
        {
            ListOfFootballMatches = new List<FootballMatch>
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