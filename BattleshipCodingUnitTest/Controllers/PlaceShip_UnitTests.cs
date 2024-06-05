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
        public void TestPlaceShip_BoardNotExist()
        {
            //Arrange 
            mock.Setup(p => p.PlaceShip()).Returns(Constant.BoardNotExist);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            // Act
            var response = battleship.PlaceShip() as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(Constant.BoardNotExist, response.Value);
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
        public void TestPlaceShip_ShipNumberLimit()
        {
            //Arrange 
            mock.Setup(p => p.PlaceShip()).Returns(Constant.ShipNumberLimit);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            // Act
            var response = battleship.PlaceShip() as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(Constant.ShipNumberLimit, response.Value);
        }
    }
}