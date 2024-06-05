using BattleshipCodingTest.Controllers;
using BattleshipCodingTest.Interfaces;
using BattleshipCodingTest.Models;
using BattleshipCodingTest.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace BattleshipCodingUnitTest.Services
{
    public class AttackShip_UnitTests
    {
        public Mock<IBattleshipService> mock = new Mock<IBattleshipService>();

        /// <summary>
        /// Verifies that the method returns target hit when ship is hitted
        /// </summary>
        [Fact]
        public void TestAttackShip_Hit()
        {
            //Arrange
            Coordinate coordinate = new Coordinate { X = 0, Y = 0 };
            mock.Setup(p => p.Attack(coordinate)).Returns(Constant.TargetHit);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var response = battleship.AttackShip(coordinate) as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(Constant.TargetHit, response.Value);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
        }


        /// <summary>
        /// Verifies that the method returns target miss when we hit wrong target
        /// </summary>
        [Fact]
        public void TestAttackShip_Miss()
        {
            //Arrange
            Coordinate coordinate = new Coordinate { X = 0, Y = 0 };
            mock.Setup(p => p.Attack(coordinate)).Returns(Constant.TargetMiss);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var response = battleship.AttackShip(coordinate) as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(Constant.TargetMiss, response.Value);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        /// Verifies that the method returns win , when user destroyes all the ships
        /// </summary>
        [Fact]
        public void TestAttackShip_Win()
        {
            //Arrange
            int count = 15;//suppose won in 15 counts.
            Coordinate coordinate = new Coordinate { X = 0, Y = 0 };
            mock.Setup(p => p.Attack(coordinate)).Returns(string.Format(Constant.GameWon, count));
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var response = battleship.AttackShip(coordinate) as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(string.Format(Constant.GameWon, count), response.Value);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        /// Verifies valid exception is thrown when target is already hitted.
        /// </summary>
        [Fact]
        public void TestAttackShip_AlreadyHit()
        {
            //Arrange
            Coordinate coordinate = new Coordinate { X = 0, Y = 0 };
            mock.Setup(p => p.Attack(coordinate)).Returns(Constant.TargetAlreadyHit);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var response = battleship.AttackShip(coordinate) as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(Constant.TargetAlreadyHit, response.Value);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        /// Verifies valid exception is thrown when board is not created.
        /// </summary>
        [Fact]
        public void TestAttackShip_BoardNotExist()
        {
            //Arrange
            Coordinate coordinate = new Coordinate { X = 0, Y = 0 };
            mock.Setup(p => p.Attack(coordinate)).Returns(Constant.BoardNotExist);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            // Act
            var response = battleship.AttackShip(coordinate) as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(Constant.BoardNotExist, response.Value);
        }

        /// <summary>
        /// Verifies valid exception is thrown when an invalid coordinate is attacked.
        /// </summary>
        [Fact]
        public void TestAttackShip_InvalidCoordinate()
        {
            //Arrange
            Coordinate coordinate = new Coordinate { X = 0, Y = 0 };
            mock.Setup(p => p.Attack(coordinate)).Returns(Constant.InvalidCoordinate);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            // Act
            var response = battleship.AttackShip(coordinate) as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(Constant.InvalidCoordinate, response.Value);
        }

        /// <summary>
        /// Verifies valid exception is thrown all ships are destroyed.
        /// </summary>
        [Fact]
        public void TestAttackShip_AllShipsDestroyed()
        {
            //Arrange
            Coordinate coordinate = new Coordinate { X = 0, Y = 0 };
            mock.Setup(p => p.Attack(coordinate)).Returns(Constant.AllShipsDestroyed);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            // Act
            var response = battleship.AttackShip(coordinate) as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(Constant.AllShipsDestroyed, response.Value);
        }

        /// <summary>
        /// Verifies valid exception is thrown all ships are destroyed.
        /// </summary>
        [Fact]
        public void TestAttackShip_NoShipsOnBoard()
        {
            //Arrange
            Coordinate coordinate = new Coordinate { X = 0, Y = 0 };
            mock.Setup(p => p.Attack(coordinate)).Returns(Constant.NoShipsOnBoard);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var response = battleship.AttackShip(coordinate) as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(Constant.NoShipsOnBoard, response.Value);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
        }
    }
}