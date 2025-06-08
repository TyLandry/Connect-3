using System;

namespace ProjectSODV
{
    class Program
    {
        static void Main(string[] args)
        {
            GameFlow game = new GameFlow(); // starts program. gameflow is an object and calls start() to begin game.
            game.Start();
        }
    }
    public class Player
    {
        public string Name { get; set; }
        public char Symbol { get; set; }

        public Player(string name, char symbol) // string = player 1 or 2, char = X or O
        {
            Name = name;
            Symbol = symbol;
        }
    }
    public class GameBoard
    {
        private char[,] board = new char[6, 7]; //Creates array to represent the 6x7 board

        public GameBoard()
        {
            Reset();
        }

        public void Reset()//This method Loops through all columns and rows setting each block to '.'
        {
            for (int row = 0; row < 6; row++)
                for (int col = 0; col < 7; col++)
                    board[row, col] = '.';
        }

        public void Display() //This method prints the current board to the console for players to see
        {
            Console.Clear();
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                    Console.Write(board[row, col] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("1 2 3 4 5 6 7\n");
        }

        public bool IsColFull(int column)
        {
            return board[0, column] != '.'; //This method checks top block of column to ensure not full
        }

        public bool Drop(int column, char symbol) //This method Searches each row  to ensure players symbol goes into lowest available spot
        {
            for (int row = 5; row >= 0; row--)
            {
                if (board[row, column] == '.')
                {
                    board[row, column] = symbol;

                    return true;
                }
            }
            return false;
        }

        public bool BoardFull() //This method checks if the board is full and returns true if so.
        {
            for (int col = 0; col < 7; col++)

                if (!IsColFull(col))

                    return false;

            return true;
        }

        public bool WinnerCheck(char symbol) //This method checks win conditions
        {
            for (int row = 0; row < 6; row++)//Only checks to last valid start for 4 straight  '--'

                for (int col = 0; col < 4; col++)

                    if (board[row, col] == symbol &&

                        board[row, col + 1] == symbol &&

                        board[row, col + 2] == symbol &&

                        board[row, col + 3] == symbol)

                        return true;

            for (int col = 0; col < 7; col++) //Only checks to last valid start for 4 straight |

                for (int row = 0; row < 3; row++)
                    if (board[row, col] == symbol &&

                        board[row + 1, col] == symbol &&

                        board[row + 2, col] == symbol &&

                        board[row + 3, col] == symbol)

                        return true;

            for (int row = 0; row < 3; row++)  //Only checks to last valid start for 4 straight '/'

                for (int col = 0; col < 4; col++)

                    if (board[row, col] == symbol &&

                        board[row + 1, col + 1] == symbol &&

                        board[row + 2, col + 2] == symbol &&

                        board[row + 3, col + 3] == symbol)

                        return true;

            for (int row = 3; row < 6; row++)  //Only checks to last valid start for 4 straight diagonally '\'

                for (int col = 0; col < 4; col++)

                    if (board[row, col] == symbol &&

                        board[row - 1, col + 1] == symbol &&

                        board[row - 2, col + 2] == symbol &&

                        board[row - 3, col + 3] == symbol)

                        return true;

            return false;
        }

    }

    public class GameFlow
    {   // encapsulation.
        private GameBoard board;
        private Player player1;
        private Player player2;
        private Player currentPlayer; // tracks whos turn it is

        public void Start() // this starts the loop
        {
            board = new GameBoard(); // initializing the gameboard. 
            player1 = new Player("Player 1", 'X');
            player2 = new Player("Player 2", 'O');
            currentPlayer = player1;

            bool PlayAgain; // asks the user if they want to play again after game ends.
            do
            {
                board.Reset(); // clear board
                bool gameOver = false;
                while (!gameOver) // continues loop until player wins 
                {
                    board.Display();
                    Console.WriteLine("Choose a column (1-7): ");
                    string input = Console.ReadLine();

                    if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7")
                    {
                        int column = int.Parse(input); // parse converts a string into a #
                    }
                    else
                    {
                        Console.WriteLine("That column is full, try another."); // error
                    }
                }
            }