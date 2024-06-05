using BattleshipCodingTest.Models;
using BattleshipCodingTest.Utilities.Helpers;

namespace BattleshipCodingUnitTest.Utilities.Helpers
{
    public class ValidCoordinateHelper_UnitTests
    {
        private readonly Board _board;

        public ValidCoordinateHelper_UnitTests()
        {
            _board = new Board(10); // Assuming a standard board size of 10x10
        }

        /// <summary>
        /// Checks if a coordinate well within the bounds of the board is valid.
        /// </summary>
        [Fact]
        public void TestIsValidCoordinate_ValidCoordinate()
        {
            // Arrange
            var coordinate = new Coordinate { X = 5, Y = 5 };

            // Act
            var isValid = ValidCoordinateHelper.IsValidCoordinate(_board, coordinate);

            // Assert
            Assert.True(isValid);
        }

        /// <summary>
        /// Tests if a coordinate with a negative X value is invalid.
        /// </summary>
        [Fact]
        public void TestIsValidCoordinate_InvalidCoordinate_NegativeX()
        {
            // Arrange
            var coordinate = new Coordinate { X = -1, Y = 5 };

            // Act
            var isValid = ValidCoordinateHelper.IsValidCoordinate(_board, coordinate);

            // Assert
            Assert.False(isValid);
        }

        /// <summary>
        /// Tests if a coordinate with a negative Y value is invalid.
        /// </summary>
        [Fact]
        public void TestIsValidCoordinate_InvalidCoordinate_NegativeY()
        {
            // Arrange
            var coordinate = new Coordinate { X = 5, Y = -1 };

            // Act
            var isValid = ValidCoordinateHelper.IsValidCoordinate(_board, coordinate);

            // Assert
            Assert.False(isValid);
        }

        /// <summary>
        /// Tests if a coordinate with an X value equal to the board size (out of bounds) is invalid.
        /// </summary>
        [Fact]
        public void TestIsValidCoordinate_InvalidCoordinate_XOutOfBounds()
        {
            // Arrange
            var coordinate = new Coordinate { X = 10, Y = 5 };

            // Act
            var isValid = ValidCoordinateHelper.IsValidCoordinate(_board, coordinate);

            // Assert
            Assert.False(isValid);
        }

        /// <summary>
        /// Tests if a coordinate with a Y value equal to the board size (out of bounds) is invalid.
        /// </summary>
        [Fact]
        public void TestIsValidCoordinate_InvalidCoordinate_YOutOfBounds()
        {
            // Arrange
            var coordinate = new Coordinate { X = 5, Y = 10 };

            // Act
            var isValid = ValidCoordinateHelper.IsValidCoordinate(_board, coordinate);

            // Assert
            Assert.False(isValid);
        }

        /// <summary>
        /// Checks if the minimum edge coordinate (0,0) is valid.
        /// </summary>
        [Fact]
        public void TestIsValidCoordinate_ValidCoordinate_EdgeCase_MinValues()
        {
            // Arrange
            var coordinate = new Coordinate { X = 0, Y = 0 };

            // Act
            var isValid = ValidCoordinateHelper.IsValidCoordinate(_board, coordinate);

            // Assert
            Assert.True(isValid);
        }

        /// <summary>
        /// Checks if the maximum edge coordinate (9,9) for a 10x10 board is valid.
        /// </summary>
        [Fact]
        public void TestIsValidCoordinate_ValidCoordinate_EdgeCase_MaxValues()
        {
            // Arrange
            var coordinate = new Coordinate { X = 9, Y = 9 };

            // Act
            var isValid = ValidCoordinateHelper.IsValidCoordinate(_board, coordinate);

            // Assert
            Assert.True(isValid);
        }
    }
}