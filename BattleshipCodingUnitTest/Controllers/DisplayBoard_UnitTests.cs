using BattleshipCodingTest.Controllers;
using BattleshipCodingTest.Interfaces;
using BattleshipCodingTest.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using System.Text;

namespace BattleshipCodingUnitTest.Services
{
    public class DisplayBoard_UnitTests
    {
        public Mock<IBattleshipService> mock = new Mock<IBattleshipService>();

        /// <summary>
        /// Verifies that method returns the created board coordinates
        /// </summary>
        [Fact]
        public void TestDisplayBoard_Success()
        {
            // Arrange
            var expectedDisplay = new StringBuilder();
            for (int row = 0; row < Constant.BoardSize; row++)
            {
                for (int col = 0; col < Constant.BoardSize; col++)
                {
                    expectedDisplay.Append($"[{row},{col}] ");
                }
                expectedDisplay.AppendLine();
            }
            var actualDisplay = expectedDisplay.ToString();
            mock.Setup(p => p.DisplayBoard()).Returns(actualDisplay);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            // Act
            var response = battleship.DisplayBoard() as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(actualDisplay, response.Value);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        /// Verifies that method returns the correct message when board does not exist
        /// </summary>
        [Fact]
        public void TestDisplayBoard_BoardNotExist()
        {
            //Arrange 
            mock.Setup(p => p.DisplayBoard()).Returns(Constant.BoardNotExist);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            // Act
            var response = battleship.DisplayBoard() as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(Constant.BoardNotExist, response.Value);
        }
    }
}