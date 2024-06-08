namespace TicTacToe
{
    public class Position
    {
        public int Number { get; set; }
        public char Marker { get; set; }

        public Position(int number)
        {
            Number = number;
            Marker = ' ';
        }

        public bool IsOccupied()
        {
            return Marker != ' ';
        }
    }
}
