using BattleshipCodingTest.Controllers;
using BattleshipCodingTest.Interfaces;
using BattleshipCodingTest.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace BattleshipCodingUnitTest.Services
{
    public class CreateBoard_UnitTests
    {
        public Mock<IBattleshipService> mock = new Mock<IBattleshipService>();

        // <summary>
        // Verifies that the board is created with the size of 10 X 10
        // </summary>
        [Fact]
        public void TestCreateBoard_Success()
        {
            //Arrange
            mock.Setup(p => p.CreateBoard()).Returns(Constant.BoardCreatedSuccessfully);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var response = battleship.CreateBoard() as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(Constant.BoardCreatedSuccessfully, response.Value);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
        }

        ///// <summary>
        ///// Verifies that the board is failed to create.
        ///// </summary>
        [Fact]
        public void TestCreateBoard_Failed()
        {
            //Arrange
            mock.Setup(p => p.CreateBoard()).Returns(Constant.BoardCreationFailed);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var response = battleship.CreateBoard() as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(Constant.BoardCreationFailed, response.Value);
        }
    }
}