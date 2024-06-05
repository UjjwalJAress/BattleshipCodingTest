using BattleshipCodingTest.Controllers;
using BattleshipCodingTest.Interfaces;
using BattleshipCodingTest.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace BattleshipCodingUnitTest.Services
{
    public class PlaceShip_UnitTests
    {
        public Mock<IBattleshipService> mock = new Mock<IBattleshipService>();

        /// <summary>
        /// Verifies valid exception is thrown when board is not created.
        /// </summary>
        [Fact]
        public void TestPlaceShip_BoardNotExist_Exception()
        {
            //Arrange
            mock.Setup(x => x.PlaceShip()).Throws(new Exception(Constant.BoardNotExist));
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var exception = Assert.Throws<Exception>(() => battleship.PlaceShip());

            //assert
            Assert.IsType<Exception>(exception);
            Assert.Equal(Constant.BoardNotExist, exception.Message);
        }

        /// <summary>
        /// Verifies that the ship is added and added ships are less than 5
        /// </summary>
        [Fact]
        public void TestPlaceShip_Success()
        {
            //Arrange
            mock.Setup(p => p.PlaceShip()).Returns(Constant.ShipPlacedSuccessfully);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var response = battleship.PlaceShip() as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(Constant.ShipPlacedSuccessfully, response.Value);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        /// Verifies that the ship added ships are less than 5
        /// </summary>
        [Fact]
        public void TestPlaceShip_ShipNumberLimit_Exception()
        {
            //Arrange
            mock.Setup(x => x.DisplayBoard()).Throws(new Exception(Constant.ShipNumberLimit));
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var exception = Assert.Throws<Exception>(() => battleship.DisplayBoard());

            //assert
            Assert.IsType<Exception>(exception);
            Assert.Equal(Constant.ShipNumberLimit, exception.Message);
        }
    }
}