using BattleshipCodingTest.Controllers;
using BattleshipCodingTest.Interfaces;
using BattleshipCodingTest.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BattleshipCodingUnitTest.Services
{
    public class RestartBoard_UnitTests
    {
        public Mock<IBattleshipService> mock = new Mock<IBattleshipService>();

        /// <summary>
        /// Verifies that game properties _hitCount and _allShipsDestroyed are reset after a restart
        /// </summary>
        [Fact]
        public void TestRestartGame_ResetsGameProperties()
        {
            //Arrange 
            mock.Setup(p => p.RestartGame()).Returns(Constant.GameRestartSuccessfully);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            // Act
            var response = battleship.RestartGame() as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(Constant.GameRestartSuccessfully, response.Value);
        }

        /// <summary>
        /// Verifies that the method throws the correct exception when the board does not exist
        /// </summary>
        [Fact]
        public void TestRestartGame_BoardNotExist()
        {
            //Arrange 
            mock.Setup(p => p.RestartGame()).Returns(Constant.GameRestartError);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            // Act
            var response = battleship.RestartGame() as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(Constant.GameRestartError, response.Value);
        }
    }
}