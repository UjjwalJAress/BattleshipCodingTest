namespace BattleshipCodingTest.Utilities.Constants
{
    public class Constant
    {
        public const int BoardSize = 10;
        public const int MaxShips = 5;
        public const int ShipSize = BoardSize / 2;
        public const string BoardSizeLimit = "Board Size should be greater than 2. Please specify a valid size.";
        public const string BoardNotExist = "Board does not exist. Please create a board first.";
        public const string InvalidCoordinate = "Please specify a valid coordinate within the board.";
        public const string ShipCannotBePlacedHorizontally = "The ship cannot be placed horizontally at the specified location.";
        public const string ShipCannotBePlacedVertically = "The ship cannot be placed vertically at the specified location.";
        public const string TargetAlreadyHit = "You have already hit this target.";
        public const string AllShipsDestroyed = "All ships are already destroyed. Please restart the game.";
        public const string GameWon = "All ships are destroyed, you won the game in {0} hits. Please restart the game.";
        public const string TargetHit = "Target Hit!";
        public const string TargetMiss = "Target Miss!";
        public const string ShipOverlap = "The ship cannot overlap with another ship.";
        public const string ShipNumberLimit = "Ship has already been placed on the board. Only 5 ship is allowed.";
        public const string ShipPlacedSuccessfully = "Ship placed successfully.";
        public const string GameRestartSuccessfully = "Game restarted Successfully, now add ship to continue futher";
        public const string BoardCreatedSuccessfully = "10 X 10 Board Created Successfully";
        public const string BoardCreationFailed = "Failed to create the board";
        public const string NoShipsOnBoard = "Ship does not exist. Please place a ship first.";
        public const char NoShipsSymbol = '-';
        public const char ShipSymbol = 'S';
        public const char TargetHitSymbol = 'H';
        public const char TargetMissSymbol = 'M';
    }
}