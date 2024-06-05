namespace BattleshipCodingTest.Models
{
    public class Ship
    {
        public int Length { get; set; }

        public List<Coordinate> Coordinates { get; set; }

        public Ship()
        {
            Coordinates = new List<Coordinate>();
        }
    }
}