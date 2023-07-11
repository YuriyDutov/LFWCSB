using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSBServer.Entities;
using FSBServer.Repositories;

namespace FSBServer.Services
{
    public class ScoreBoardService: IScoreBoardService
    {
        private readonly IScoreBoardRepository _repository;

        public ScoreBoardService(IScoreBoardRepository repository)
        {
            _repository = repository;
        }

        public List<FootballMatch> GetCurrentFootballMatches()
        {
            return _repository.Get()
                .Where(x => x.InProgress == true)
                .OrderByDescending(m => m.TotalScore)
                .ToList();
        }

        public bool StartNewMatch(FootballMatch footballMatch)
        {
            return _repository.Create(footballMatch);
        }

        public bool EndCurrentMatch(int id)
        {
            var footballMatch = _repository.Get().FirstOrDefault(x => x.Id == id);
            if (footballMatch == null)
            {
                return false;
            }
            footballMatch.InProgress = false;

            return _repository.Update(footballMatch);
        }

        public bool UpdateMatchScore(int id, int homeTeamScore, int awayTeamScore)
        {
            var footballMatch = _repository.Get().FirstOrDefault(x => x.Id == id);
            if (footballMatch == null)
            {
                return false;
            }
            footballMatch.HomeTeamScore = homeTeamScore;
            footballMatch.AwayTeamScore = awayTeamScore;
            footballMatch.TotalScore = homeTeamScore + awayTeamScore;

            return _repository.Update(footballMatch);
        }
    }
}
