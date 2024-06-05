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
            mock.Setup(p => p.Attack(It.IsAny<Coordinate>())).Returns(Constant.TargetHit);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var response = battleship.AttackShip(new Coordinate { X = 1, Y = 1 }) as OkObjectResult;

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
            mock.Setup(p => p.Attack(It.IsAny<Coordinate>())).Returns(Constant.TargetMiss);
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var response = battleship.AttackShip(new Coordinate { X = 0, Y = 1 }) as OkObjectResult;

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
            mock.Setup(p => p.Attack(It.IsAny<Coordinate>())).Returns(string.Format(Constant.GameWon, count));
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var response = battleship.AttackShip(new Coordinate { X = 1, Y = 2 }) as OkObjectResult;

            //assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(string.Format(Constant.GameWon, count), response.Value);
            Assert.Equal((int)HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        /// Verifies valid exception is thrown when target is already hitted.
        /// </summary>
        [Fact]
        public void TestAttackShip_AlreadyHit_Exception()
        {
            //Arrange
            mock.Setup(x => x.Attack(It.IsAny<Coordinate>())).Throws(new Exception(Constant.TargetAlreadyHit));
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var exception = Assert.Throws<Exception>(() => battleship.AttackShip(new Coordinate { X = 2, Y = 1 }));

            //assert
            Assert.IsType<Exception>(exception);
            Assert.Equal(Constant.TargetAlreadyHit, exception.Message);
        }

        /// <summary>
        /// Verifies valid exception is thrown when board is not created.
        /// </summary>
        [Fact]
        public void TestAttackShip_BoardNotExist_Exception()
        {
            //Arrange
            mock.Setup(x => x.Attack(It.IsAny<Coordinate>())).Throws(new Exception(Constant.BoardNotExist));
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var exception = Assert.Throws<Exception>(() => battleship.AttackShip(new Coordinate { X = 1, Y = 2 }));

            //assert
            Assert.IsType<Exception>(exception);
            Assert.Equal(Constant.BoardNotExist, exception.Message);
        }

        /// <summary>
        /// Verifies valid exception is thrown when an invalid coordinate is attacked.
        /// </summary>
        [Fact]
        public void TestAttackShip_InvalidCoordinate_Exception()
        {
            //Arrange
            mock.Setup(x => x.Attack(It.IsAny<Coordinate>())).Throws(new Exception(Constant.InvalidCoordinate));
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var exception = Assert.Throws<Exception>(() => battleship.AttackShip(new Coordinate { X = 1, Y = 1 }));

            //assert
            Assert.IsType<Exception>(exception);
            Assert.Equal(Constant.InvalidCoordinate, exception.Message);
        }

        /// <summary>
        /// Verifies valid exception is thrown all ships are destroyed.
        /// </summary>
        [Fact]
        public void TestAttackShip_AllShipsDestroyed_Exception()
        {
            //Arrange
            mock.Setup(x => x.Attack(It.IsAny<Coordinate>())).Throws(new Exception(Constant.AllShipsDestroyed));
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var exception = Assert.Throws<Exception>(() => battleship.AttackShip(new Coordinate { X = 1, Y = 2 }));

            //assert
            Assert.IsType<Exception>(exception);
            Assert.Equal(Constant.AllShipsDestroyed, exception.Message);
        }

        /// <summary>
        /// Verifies valid exception is thrown all ships are destroyed.
        /// </summary>
        [Fact]
        public void TestAttackShip_NoShipsOnBoard_Exception()
        {
            //Arrange
            mock.Setup(x => x.Attack(It.IsAny<Coordinate>())).Throws(new Exception(Constant.NoShipsOnBoard));
            BattleshipApiController battleship = new BattleshipApiController(mock.Object);

            //Act
            var exception = Assert.Throws<Exception>(() => battleship.AttackShip(new Coordinate { X = 4, Y = 1 }));

            //assert
            Assert.IsType<Exception>(exception);
            Assert.Equal(Constant.NoShipsOnBoard, exception.Message);
        }
    }
}