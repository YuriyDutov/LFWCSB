using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace FootballScoreBoard.Tests
{
    public class ScoreBoardServiceTests
    {
        [Fact]
        public void GetCurrentFootballMatches_GetsCurrentFootballMatches_ReturnListOfFootballMatchesOrderedByTotalScoreAndInProgressIsTrue()
        { 
            //Arrange
            var scoreBoardRepository = new ScoreBoardRepository();
            var scoreBoardService = new ScoreBoardService(scoreBoardRepository);

            //Act
            List<FootballMatch> result = scoreBoardService.GetCurrentFootballMatches();

            //Assert
            result.Should().BeOfType(typeof(List<FootballMatch>));
            result.Should().BeInDescendingOrder(x => x.TotalScore);
            result.Should().OnlyContain(x => x.InProgress == true);
        }

        [Fact]
        public void StartFootballMatch_CreatesFootballMatchEntityWithInProgressIsTrue_ReturnTrue()
        { 
            //Arrange

            //Act

            //Assert
        }

        [Fact]
        public void FinishFootballMatch_UpdatesFootballMatchEntityWithInProgressIsFalse_ReturnTrue()
        { 
            //Arrange

            //Act

            //Assert

        }

        [Fact]
        public void UpdateScore_UpdatesFootballMatchEntityScore_ReturnTrue()
        { 
            //Arrange

            //Act

            //Assert
        }
    }

    public class FootballMatch
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public int TotalScore { get; set; }
        public bool InProgress { get; set; }
    }

    public class ScoreBoardService
    {
        private readonly IScoreBoardRepository _repository;

        public ScoreBoardService(IScoreBoardRepository repository)
        {
            _repository = repository;
        }

        public List<FootballMatch> GetCurrentFootballMatches()
        {
            return _repository.Get().Where(x => x.InProgress == true).OrderByDescending(m => m.TotalScore).ToList();
        }
    }

    public interface IScoreBoardRepository
    {
        List<FootballMatch> Get();
    }

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
