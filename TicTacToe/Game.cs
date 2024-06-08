using System;

namespace TicTacToe
{
    public class Game
    {
        private GameBoard _board;
        private Player _player1;
        private Player _player2;
        private Player _currentPlayer;

        public Game(Player player1, Player player2)
        {
            _board = new GameBoard();
            _player1 = player1;
            _player2 = player2;
            _currentPlayer = _player1;
        }

        public void Play()
        {
            bool gameEnded = false;

            while (!gameEnded)
            {
                Console.Clear();
                _board.Display();
                Console.WriteLine($"{_currentPlayer.Name}'s turn ({_currentPlayer.Marker})");
                Console.Write("Select a position (1-9): ");

                if (int.TryParse(Console.ReadLine(), out int position) && _board.PlaceMarker(position, _currentPlayer.Marker))
                {
                    if (CheckWinner())
                    {
                        Console.Clear();
                        _board.Display();
                        Console.WriteLine($"{_currentPlayer.Name} wins!");
                        gameEnded = true;
                    }
                    else if (IsBoardFull())
                    {
                        Console.Clear();
                        _board.Display();
                        Console.WriteLine("It's a tie!");
                        gameEnded = true;
                    }
                    else
                    {
                        SwitchPlayer();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid position. Please try again.");
                }
            }
        }

        private void SwitchPlayer()
        {
            _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
        }

        private bool CheckWinner()
        {
            int[,] winningCombinations = new int[,]
            {
                {0, 1, 2},
                {3, 4, 5},
                {6, 7, 8},
                {0, 3, 6},
                {1, 4, 7},
                {2, 5, 8},
                {0, 4, 8},
                {2, 4, 6}
            };

            for (int i = 0; i < winningCombinations.GetLength(0); i++)
            {
                if (_board.Positions[winningCombinations[i, 0]].Marker == _currentPlayer.Marker &&
                    _board.Positions[winningCombinations[i, 1]].Marker == _currentPlayer.Marker &&
                    _board.Positions[winningCombinations[i, 2]].Marker == _currentPlayer.Marker)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsBoardFull()
        {
            foreach (var position in _board.Positions)
            {
                if (!position.IsOccupied())
                {
                    return false;
                }
            }

            return true;
        }
    }
}

