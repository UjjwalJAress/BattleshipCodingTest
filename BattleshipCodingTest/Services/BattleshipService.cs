using BattleshipCodingTest.Interfaces;
using BattleshipCodingTest.Models;
using BattleshipCodingTest.Utilities.Constants;
using BattleshipCodingTest.Utilities.Helpers;
using System.Text;

namespace BattleshipCodingTest.Services
{
    public class BattleshipService : IBattleshipService
    {
        #region Global Properties
        public static Board _board = new Board(0);
        public static int _hitCount;
        public static bool _allShipsDestroyed;
        #endregion
        #region Command Services

        /// <summary>
        /// creates the board of specified size 10
        /// </summary>
        public string CreateBoard()
        {
            _hitCount = 0;
            _allShipsDestroyed = false;
            _board = new Board(Constant.BoardSize);
            if (_board == null) 
            {
                throw new Exception(Constant.BoardCreationFailed);
            }
            else 
            {
                return Constant.BoardCreatedSuccessfully;
            }
        }

        /// <summary>
        /// places the ship randomnly only 5 ships are allowed
        /// </summary>
        public string PlaceShip()
        {
            if (_board != null && _board.Size != 0)
            {
                if (_board.Ships.Count >= Constant.MaxShips)
                {
                    throw new Exception(Constant.ShipNumberLimit);
                }

                var ship = new Ship { Length = Constant.ShipSize };
                bool shipPlaced = false;
                Random random = new Random();

                while (!shipPlaced)
                {
                    bool isHorizontal = random.Next(2) == 0;
                    int maxX = isHorizontal ? _board.Size : _board.Size - ship.Length + 1;
                    int maxY = isHorizontal ? _board.Size - ship.Length + 1 : _board.Size;

                    int startX = random.Next(maxX);
                    int startY = random.Next(maxY);

                    var start = new Coordinate { X = startX, Y = startY };

                    if (start == null || !ValidCoordinateHelper.IsValidCoordinate(_board, start))
                    {
                        continue;
                    }

                    bool validPlacement = true;

                    for (int i = 0; i < ship.Length; i++)
                    {
                        if (isHorizontal && _board.Grid[start.X, start.Y + i] == Constant.ShipSymbol)
                        {
                            validPlacement = false;
                            break;
                        }
                        else if (!isHorizontal && _board.Grid[start.X + i, start.Y] == Constant.ShipSymbol)
                        {
                            validPlacement = false;
                            break;
                        }
                    }

                    if (!validPlacement)
                    {
                        continue;
                    }

                    for (int i = 0; i < ship.Length; i++)
                    {
                        if (isHorizontal)
                        {
                            _board.Grid[start.X, start.Y + i] = Constant.ShipSymbol;
                            ship.Coordinates.Add(new Coordinate(start.X, start.Y + i));
                        }
                        else
                        {
                            _board.Grid[start.X + i, start.Y] = Constant.ShipSymbol;
                            ship.Coordinates.Add(new Coordinate(start.X + i, start.Y));
                        }
                    }
                    _board.Ships.Add(ship);
                    shipPlaced = true;
                }
                return Constant.ShipPlacedSuccessfully;
            }
            else
            {
                throw new Exception(Constant.BoardNotExist);
            }
        }

        /// <summary>
        /// attack to specific co-ordinate to destroy the ship
        /// </summary>
        /// <param name="target"></param>
        public string Attack(Coordinate target)
        {
            if (_board != null && _board.Size != 0)
            {
                if (_allShipsDestroyed)
                {
                    throw new Exception(Constant.AllShipsDestroyed);
                }

                if (_board.Ships.Count <= 0)
                {
                    throw new Exception(Constant.NoShipsOnBoard);
                }

                if (target == null || !ValidCoordinateHelper.IsValidCoordinate(_board, target))
                {
                    throw new Exception(Constant.InvalidCoordinate);
                }

                char cell = _board.Grid[target.X, target.Y];

                if (cell == Constant.TargetHitSymbol || cell == Constant.TargetMissSymbol)
                {
                    throw new Exception(Constant.TargetAlreadyHit);
                }

                if (cell == Constant.ShipSymbol)
                {
                    _board.Grid[target.X, target.Y] = Constant.TargetHitSymbol;
                    _hitCount++;
                    _allShipsDestroyed = ShipDestroyedValidator.AreAllShipsDestroyed(_board);

                    if (_allShipsDestroyed)
                    {
                        return string.Format(Constant.GameWon, _hitCount);
                    }
                    else
                    {
                        return Constant.TargetHit;
                    }
                }
                else
                {
                    _board.Grid[target.X, target.Y] = Constant.TargetMissSymbol;
                    _hitCount++;
                    return Constant.TargetMiss;
                }
            }
            else
            {
                throw new Exception(Constant.BoardNotExist);
            }
        }

        #endregion

        #region Query Services
        /// <summary>
        /// Display board with successfully hitted ship and missed hits.
        /// </summary>
        public string DisplayBoard()
        {
            if (_board != null && _board.Size != 0)
            {
                var display = new StringBuilder();

                for (int row = 0; row < _board.Size; row++)
                {
                    for (int col = 0; col < _board.Size; col++)
                    {
                        // Check if the coordinate has been attacked and update the display accordingly
                        char status = _board.Grid[row, col];
                        switch (status)
                        {
                            case Constant.NoShipsSymbol:
                                display.Append($"[{row},{col}] ");
                                break;
                            case Constant.TargetHitSymbol:
                                display.Append("[ S ] ");
                                break;
                            case Constant.ShipSymbol:
                                display.Append($"[{row},{col}] ");
                                break;
                            case Constant.TargetMissSymbol:
                                display.Append("[ M ] ");
                                break;
                            default:
                                break;
                        }
                    }
                    display.AppendLine();
                }
                return display.ToString();
            }
            else
            {
                throw new Exception(Constant.BoardNotExist);
            }
        }

        /// <summary>
        /// Restarts the game with new board of size 10 X 10
        /// </summary>
        public string RestartGame()
        {
            if (_board != null && _board.Size != 0)
            {
                _board = new Board(_board.Size);
                _hitCount = 0;
                _allShipsDestroyed = false;
                _board.Ships.Clear();
                return Constant.GameRestartSuccessfully;
            }
            else
            {
                throw new Exception(Constant.BoardNotExist);
            }
        }
        #endregion
    }
}