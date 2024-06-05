namespace BattleshipCodingTest.Models
{
    public class Board
    {
        public int Size { get;  set; }
        public char[,] Grid { get;  set; }
        public List<Ship> Ships { get; set; }
        public Board(int size)
        {
            Size = size;
            Grid = new char[size, size];
            Ships = new List<Ship>();

            // Initializing the grid with empty values
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Grid[i, j] = '-';
                }
            }
        }
    }
}