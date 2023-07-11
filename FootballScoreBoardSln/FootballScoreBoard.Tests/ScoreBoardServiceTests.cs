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
}
