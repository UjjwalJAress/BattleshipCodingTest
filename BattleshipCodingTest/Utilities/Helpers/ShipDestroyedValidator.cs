using BattleshipCodingTest.Models;

namespace BattleshipCodingTest.Utilities.Helpers
{
    public class ShipDestroyedValidator
    {
        /// <summary>
        /// Checks whether the all ships are destroyed or not?
        /// </summary>
        /// <param name="board"></param>
        /// <returns>true or false</returns>
        public static bool AreAllShipsDestroyed(Board board)
        {
            foreach (var ship in board.Ships)
            {
                if (ship.Coordinates.Any(c => board.Grid[c.X, c.Y] != 'H'))
                {
                    return false;
                }
            }
            return true;
        }
    }
}