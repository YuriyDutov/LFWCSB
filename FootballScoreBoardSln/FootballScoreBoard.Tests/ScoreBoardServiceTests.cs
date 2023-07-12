using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FSBServer.Entities;
using FSBServer.Repositories;
using FSBServer.Services;
using Xunit;

namespace FootballScoreBoard.Tests
{
    public class ScoreBoardServiceTests
    {
        private static readonly IScoreBoardRepository Repository = new ScoreBoardRepository();
        private readonly IScoreBoardService _scoreBoardService = new ScoreBoardService(Repository);

        [Fact]
        public void GetCurrentFootballMatches_GetsCurrentFootballMatches_ReturnListOfFootballMatchesOrderedByTotalScoreAndInProgressIsTrue()
        { 
            //Act
            List<FootballMatch> result = _scoreBoardService.GetCurrentFootballMatches();

            //Assert
            result.Should().BeOfType(typeof(List<FootballMatch>));
            result.Should().BeInDescendingOrder(x => x.TotalScore);
            result.Should().OnlyContain(x => x.InProgress == true);
        }

        [Fact]
        public void StartFootballMatch_CreatesFootballMatchEntityWithInProgressIsTrue_ReturnTrue()
        { 
            //Arrange
            var countOfMatches = _scoreBoardService.GetCurrentFootballMatches().Count;
            var id = _scoreBoardService.GetCurrentFootballMatches().Max(m => m.Id) + 1;
            var footballMatch = new FootballMatch
            {
                HomeTeam = "England",
                AwayTeam = "Wales",
                Id = id,
                InProgress = true
            };

            //Act
            var result = _scoreBoardService.StartNewMatch(footballMatch);
            var expectedCountOfMatches = _scoreBoardService.GetCurrentFootballMatches().Count;

            //Assert
            result.Should().Be(true);
            expectedCountOfMatches.Should().BeGreaterThan(countOfMatches);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void FinishFootballMatch_UpdatesFootballMatchEntityWithInProgressIsFalse_ReturnTrueIfEntityFound(int id)
        { 
            //Arrange
            var countOfMatches = _scoreBoardService.GetCurrentFootballMatches().Count;

            //Act
            var result = _scoreBoardService.EndCurrentMatch(id);
            var expectedCountOfMatches = _scoreBoardService.GetCurrentFootballMatches().Count;

            //Assert
            result.Should().Be(true);
            expectedCountOfMatches.Should().BeLessThan(countOfMatches);

        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void FinishFootballMatch_UpdatesFootballMatchEntityWithInProgressIsFalse_ReturnFalseIfEntityNotFound(int id)
        { 
            //Act
            var result = _scoreBoardService.EndCurrentMatch(id);

            //Assert
            result.Should().Be(false);
        }

        [Theory]
        [InlineData(3, 3, 2)]
        [InlineData(5, 2, 3)]
        public void UpdateScore_UpdatesFootballMatchEntityScore_ReturnTrueIfEntityFound(int id, int homeTeamScore, int awayTeamScore)
        {
            //Act
            var result = _scoreBoardService.UpdateMatchScore(id, homeTeamScore, awayTeamScore);
            
            //Assert
            result.Should().Be(true);
        }

        [Theory]
        [InlineData(10, 3, 2)]
        [InlineData(20, 2, 3)]
        public void UpdateScore_UpdatesFootballMatchEntityScore_ReturnFalseIfEntityFound(int id, int homeTeamScore, int awayTeamScore)
        {
            //Act
            var result = _scoreBoardService.UpdateMatchScore(id, homeTeamScore, awayTeamScore);

            //Assert
            result.Should().Be(false);
        }

        [Theory]
        [InlineData(3, 3, 2)]
        [InlineData(5, 2, 3)]
        public void UpdateScore_UpdatesFootballMatchEntityScore_TotalScoreMustChanged(int id, int homeTeamScore, int awayTeamScore)
        {
            //Arrange
            var totalScore = homeTeamScore + awayTeamScore;

            //Act
            _scoreBoardService.UpdateMatchScore(id, homeTeamScore, awayTeamScore);
            var expectedTotalScore = _scoreBoardService.GetCurrentFootballMatches()
                .First(i => i.Id == id).TotalScore;

            //Assert
            expectedTotalScore.Should().Be(totalScore);
        }
    }
}
