using System;
using Xunit;

namespace FootballScoreBoard.Tests
{
    public class ScoreBoardServiceTests
    {
        [Fact]
        public void GetCurrentFootballMatches_GetsCurrentFootballMatches_ReturnListOfFootballMatchesOrderedByTotalScoreAndInProgressIsTrue()
        { 
            ////Arrange

            //Act

            //Assert
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
