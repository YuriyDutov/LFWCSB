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
            throw new NotImplementedException();
        }

        public bool EndCurrentMatch(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMatchScore(int id, int homeTeamScore, int awayTeamScore)
        {
            throw new NotImplementedException();
        }
    }
}
