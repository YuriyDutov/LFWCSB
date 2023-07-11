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
            var scoreBoardRepository = new ScoreBoardRepository();
            var scoreBoardService = new ScoreBoardService(scoreBoardRepository);
            var countOfMatches = scoreBoardService.GetCurrentFootballMatches().Count;
            var id = scoreBoardService.GetCurrentFootballMatches().Max(m => m.Id) + 1;
            var footballMatch = new FootballMatch
            {
                HomeTeam = "England",
                AwayTeam = "Wales",
                Id = id,
                InProgress = true
            };

            //Act
            var result = scoreBoardService.StartNewMatch(footballMatch);
            var expectedCountOfMatches = scoreBoardService.GetCurrentFootballMatches().Count;

            //Assert
            result.Should().Be(true);
            expectedCountOfMatches.Should().BeGreaterThan(countOfMatches);
        }

        [Fact]
        public void FinishFootballMatch_UpdatesFootballMatchEntityWithInProgressIsFalse_ReturnTrue()
        { 
            //Arrange
            var scoreBoardRepository = new ScoreBoardRepository();
            var scoreBoardService = new ScoreBoardService(scoreBoardRepository);
            var countOfMatches = scoreBoardService.GetCurrentFootballMatches().Count;
            var id = 1;

            //Act
            var result = scoreBoardService.EndCurrentMatch(id);
            var expectedCountOfMatches = scoreBoardService.GetCurrentFootballMatches().Count;

            //Assert
            result.Should().Be(true);
            expectedCountOfMatches.Should().BeLessThan(countOfMatches);

        }

        [Fact]
        public void UpdateScore_UpdatesFootballMatchEntityScore_ReturnTrue()
        { 
            //Arrange
            var scoreBoardRepository = new ScoreBoardRepository();
            var scoreBoardService = new ScoreBoardService(scoreBoardRepository);
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
            var result = scoreBoardService.UpdateMatchScore(match.Id, match.HomeTeamScore, match.AwayTeamScore);
            var expectedTotalScore = scoreBoardService.GetCurrentFootballMatches().First(i => i.Id == match.Id).TotalScore;

            //Assert
            result.Should().Be(true);
            expectedTotalScore.Should().BeGreaterThan(match.TotalScore);
        }
    }
}
