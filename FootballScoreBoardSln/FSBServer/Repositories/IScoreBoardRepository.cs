using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSBServer.Entities;

namespace FSBServer.Repositories
{
    public interface IScoreBoardRepository
    {
        List<FootballMatch> Get();
    }
}
