using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSBServer.Entities;

namespace FSBServer.Services
{
    public interface IScoreBoardService
    {
        List<FootballMatch> GetCurrentFootballMatches();

        bool StartNewMatch(FootballMatch footballMatch);

        bool EndCurrentMatch(int id);

        bool UpdateMatchScore(int id, int homeTeamScore, int awayTeamScore);
    }
}
