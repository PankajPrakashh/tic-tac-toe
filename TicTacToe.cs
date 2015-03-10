using System;

namespace CodeForWin
{
    /// <summary>
    /// TicTacToe being an interesting game. Everybody has played in his childhood.
    /// This class can be used to play a tic tac toe game on the console. 
    /// This class implements two player game.
    /// </summary>
    class TicTacToe
    {
        //3x3 tic tac toe game board.
        private char[,] Board;

        //Specifies the current player.
        private int CurrentPlayer;

        /// <summary>
        /// Allocates a new object and initlizes the board to its initlial state.
        /// </summary>
        public TicTacToe()
        {
            Board = new char[3, 3];
            NewGame();
        }

        /// <summary>
        /// Starts a new game and initializes the game board to its initial state.
        /// - means the position is empty.
        /// x means the position is occupied by first player.
        /// 0 measn the position is occupied by second player.
        /// </summary>
        public void NewGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = '-';
                }
            }

            CurrentPlayer = 1;
        }

        /// <summary>
        /// Performs a move to the specified position and occupies the position by the current player.
        /// </summary>
        /// <param name="Position">Position on the board. Row and column no(1-3) of the tic tac toe board.</param>
        public void Move(int Row, int Col)
        {
            //Check for a valid row and column number. (1-3)
            if (Row >= 1 && Row <= 3 && Col >= 1 && Col <= 3)
            {
                //Check if the current position is empty or not.
                if (Board[Row - 1, Col - 1] == '-')
                {
                    //If the current player is 1 then assign X to the current position of board. 
                    //Else assign 0. Also change the current player.
                    if (CurrentPlayer == 1)
                    {
                        Board[Row - 1, Col - 1] = 'X';
                        CurrentPlayer = 2;
                    }
                    else
                    {
                        Board[Row - 1, Col - 1] = '0';
                        CurrentPlayer = 1;
                    }
                }
                else
                {
                    Console.WriteLine("The current position is not free. Try again.");
                }
            } 
            else
            {
                Console.WriteLine("Row or column number out of range. Try again.");
            }
        }

        /// <summary>
        /// Checks the current board status. Whether any player has won the game or the game is draw or the game will continue more.
        /// </summary>
        /// <returns>
        /// Returns a character. 
        /// Returns X if first player has won.
        /// Returns 0 if the second player has won.
        /// Returns = if the game is draw.
        /// Returns - if the game will continue more.
        /// </returns>
        public char Check()
        {
            char Result = '=';

            //Checks if the game will continue or not.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i, j] == '-')
                    {
                        Result = '-';
                    }
                }
            }

            //Checks horizontally for any match. First checks the first row, then second and then third.
            if (Board[0, 0] == Board[0, 1] && Board[0, 0] == Board[0, 2])
                Result = Board[0, 0];
            else if (Board[1, 0] == Board[1, 1] && Board[1, 0] == Board[1, 2])
                Result = Board[1, 0];
            else if (Board[2, 0] == Board[2, 1] && Board[2, 0] == Board[2, 2])
                Result = Board[2, 0];

            //Checks vertically for any match. First checks the first column, then second and at last the third one.
            if (Board[0, 0] == Board[1, 0] && Board[0, 0] == Board[2, 0])
                Result = Board[0, 0];
            else if (Board[0, 1] == Board[1, 1] && Board[0, 1] == Board[2, 1])
                Result = Board[0, 1];
            else if (Board[0, 2] == Board[1, 2] && Board[0, 2] == Board[2, 2])
                Result = Board[0, 2];

            //Checks diagonally for any match.
            if (Board[0, 0] == Board[1, 1] && Board[0, 0] == Board[2, 2])
                Result = Board[0, 0];
            else if (Board[0, 2] == Board[1, 1] && Board[0, 2] == Board[2, 0])
                Result = Board[0, 2];

            return Result;
        }

        /// <summary>
        /// Prints the current status of the game board.
        /// </summary>
        public void PrintBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            TicTacToe t = new TicTacToe();
            int r, c;
            string temp;

            while (true)
            {
                t.PrintBoard();
                Console.WriteLine("\nEnter the space separated row and column : ");
                temp = Console.ReadLine();
                r = Convert.ToInt32(temp.Split(' ')[0]);
                c = Convert.ToInt32(temp.Split(' ')[1]);
                t.Move(r, c);

                char ch = t.Check();
                switch (ch)
                {
                    case '=': Console.WriteLine("MATCH DRAW");
                        break;
                    case 'X': Console.WriteLine("PLAYER 1 WINS");
                        break;
                    case '0': Console.WriteLine("PLAYER 2 WINS");
                        break;
                }

                if (ch != '-')
                    break;
            }

            Console.ReadKey();
        }
    }
}
