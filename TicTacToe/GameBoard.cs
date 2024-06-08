using System;

namespace TicTacToe
{
    public class GameBoard
    {
        public Position[] Positions { get; set; }

        public GameBoard()
        {
            Positions = new Position[9];
            for (int i = 0; i < 9; i++)
            {
                Positions[i] = new Position(i + 1);
            }
        }

        public void Display()
        {
            for (int i = 0; i < 9; i++)
            {
                Console.Write($"|{(Positions[i].IsOccupied() ? Positions[i].Marker : Positions[i].Number.ToString())}|");
                if ((i + 1) % 3 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        public bool PlaceMarker(int positionNumber, char marker)
        {
            if (positionNumber < 1 || positionNumber > 9)
            {
                return false;
            }

            if (Positions[positionNumber - 1].IsOccupied())
            {
                return false;
            }

            Positions[positionNumber - 1].Marker = marker;
            return true;
        }
    }
}
