using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSBServer.Entities;

namespace FSBServer.DataSources
{
    public interface IDataSource
    {
        List<FootballMatch> GetData();

        bool Add(FootballMatch footballMatch);

        bool Update(FootballMatch footballMatch);

        bool Delete(int id);
    }
}
