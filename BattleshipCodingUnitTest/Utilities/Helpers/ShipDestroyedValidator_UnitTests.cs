using BattleshipCodingTest.Models;
using BattleshipCodingTest.Utilities.Constants;
using BattleshipCodingTest.Utilities.Helpers;

namespace BattleshipCodingUnitTest.Utilities.Helpers
{
    public class ShipDestroyedValidator_UnitTests
    {

        /// <summary>
        /// Verifies that the method returns true when all ships on the board are marked as destroyed.
        /// </summary>
        [Fact]
        public void TestAreAllShipsDestroyed_AllShipsDestroyed()
        {
            // Arrange
            var board = new Board(10);
            var ship1 = new Ship { Coordinates = new List<Coordinate> { new Coordinate { X = 0, Y = 0 } } };
            var ship2 = new Ship { Coordinates = new List<Coordinate> { new Coordinate { X = 1, Y = 1 } } };
            board.Ships.Add(ship1);
            board.Ships.Add(ship2);

            // Mark both ships as destroyed
            board.Grid[0, 0] = Constant.TargetHitSymbol;
            board.Grid[1, 1] = Constant.TargetHitSymbol;

            // Act
            var allShipsDestroyed = ShipDestroyedValidator.AreAllShipsDestroyed(board);

            // Assert
            Assert.True(allShipsDestroyed);
        }

        /// <summary>
        /// Verifies that the method returns false when at least one ship on the board is not destroyed.
        /// </summary>
        [Fact]
        public void TestAreAllShipsDestroyed_NotAllShipsDestroyed()
        {
            // Arrange
            var board = new Board(10);
            var ship1 = new Ship { Coordinates = new List<Coordinate> { new Coordinate { X = 0, Y = 0 } } };
            var ship2 = new Ship { Coordinates = new List<Coordinate> { new Coordinate { X = 1, Y = 1 } } };
            board.Ships.Add(ship1);
            board.Ships.Add(ship2);

            // Mark only one ship as destroyed
            board.Grid[0, 0] = Constant.TargetHitSymbol;

            // Act
            var allShipsDestroyed = ShipDestroyedValidator.AreAllShipsDestroyed(board);

            // Assert
            Assert.False(allShipsDestroyed);
        }

        /// <summary>
        /// Verifies that the method returns true when the board has no ships (empty).
        /// </summary>
        [Fact]
        public void TestAreAllShipsDestroyed_EmptyBoard()
        {
            // Arrange
            var board = new Board(10);

            // Act
            var allShipsDestroyed = ShipDestroyedValidator.AreAllShipsDestroyed(board);

            // Assert
            Assert.True(allShipsDestroyed);
        }
    }
}