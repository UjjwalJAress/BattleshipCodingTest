using BattleshipCodingTest.Models;

namespace BattleshipCodingTest.Utilities.Helpers
{
    public class ValidCoordinateHelper
    {
        /// <summary>
        /// checks whether selected co-ordinates are valid or not?
        /// </summary>
        /// <param name="board"></param>
        /// <param name="coordinate"></param>
        /// <returns>true or false</returns>
        public static bool IsValidCoordinate(Board board, Coordinate coordinate)
        {
            return coordinate.X >= 0 && coordinate.X < board.Size && coordinate.Y >= 0 && coordinate.Y < board.Size;
        }
    }
}