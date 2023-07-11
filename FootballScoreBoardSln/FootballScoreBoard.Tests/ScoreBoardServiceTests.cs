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

        [Fact]
        public void FinishFootballMatch_UpdatesFootballMatchEntityWithInProgressIsFalse_ReturnTrue()
        { 
            //Arrange
            var countOfMatches = _scoreBoardService.GetCurrentFootballMatches().Count;
            var id = 1;

            //Act
            var result = _scoreBoardService.EndCurrentMatch(id);
            var expectedCountOfMatches = _scoreBoardService.GetCurrentFootballMatches().Count;

            //Assert
            result.Should().Be(true);
            expectedCountOfMatches.Should().BeLessThan(countOfMatches);

        }

        [Fact]
        public void UpdateScore_UpdatesFootballMatchEntityScore_ReturnTrue()
        { 
            //Arrange
            var match = new FootballMatch
            {
                Id = 5,
                HomeTeam = "Argentina",
                AwayTeam = "Australia",
                HomeTeamScore = 3,
                AwayTeamScore = 1,
                InProgress = true,
                TotalScore = 4
            };

            //Act
            match.AwayTeamScore++;
            var result = _scoreBoardService.UpdateMatchScore(match.Id, match.HomeTeamScore, match.AwayTeamScore);
            var expectedTotalScore = _scoreBoardService.GetCurrentFootballMatches()
                .First(i => i.Id == match.Id)
                .TotalScore;

            //Assert
            result.Should().Be(true);
            expectedTotalScore.Should().BeGreaterThan(match.TotalScore);
        }
    }
}
