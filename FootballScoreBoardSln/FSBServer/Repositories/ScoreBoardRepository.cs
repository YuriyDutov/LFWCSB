using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSBServer.DataSources;
using FSBServer.Entities;

namespace FSBServer.Repositories
{
    public class ScoreBoardRepository: IScoreBoardRepository
    {
        private readonly IDataSource _dataSource = ScoreBoardDataSource.GetDataSource();

        public List<FootballMatch> Get()
        {
            return _dataSource.GetData();
        }

        public bool Create(FootballMatch footballMatch)
        {
            return _dataSource.Add(footballMatch);
        }

        public bool Update(FootballMatch footballMatch)
        {
            return _dataSource.Update(footballMatch);
        }
    }
}
