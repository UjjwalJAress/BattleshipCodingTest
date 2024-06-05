using BattleshipCodingTest.Models;

namespace BattleshipCodingTest.Interfaces
{
    public interface IBattleshipService
    {
        string CreateBoard();
        string PlaceShip();
        string Attack(Coordinate target);
        string DisplayBoard();
        string RestartGame();
    }
}