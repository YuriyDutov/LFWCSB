using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace FootballScoreBoard.Tests
{
    public class ScoreBoardServiceTests
    {
        [Fact]
        public void GetCurrentFootballMatches_GetsCurrentFootballMatches_ReturnListOfFootballMatchesOrderedByTotalScoreAndInProgressIsTrue()
        { 
            ////Arrange
            var scoreBoardService = new ScoreBoardService();

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
        public List<FootballMatch> GetCurrentFootballMatches()
        {
            throw new NotImplementedException();
        }
    }
}
