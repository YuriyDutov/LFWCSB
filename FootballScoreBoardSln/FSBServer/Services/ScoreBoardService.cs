using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSBServer.Entities;
using FSBServer.Repositories;

namespace FSBServer.Services
{
    public class ScoreBoardService
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
    }
}
