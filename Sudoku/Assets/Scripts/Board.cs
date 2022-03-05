using Roy.Sudoku.Static;

namespace Roy.Sudoku.Model
{
    public class Board
    {
        public const int SIZE = 9;
        public const int GROUP_SIZE = 3;

        private SquareModel[,] _gameBoard;
        public SquareModel[,] GameBoard
        {
            get
            {
                return _gameBoard;
            }
            set
            {
                _gameBoard = value;
            }
        }

        public Board()
        {
            _gameBoard = new SquareModel[SIZE, SIZE];
            newEmptyBoard(0);
        }

        public Board(int[,] data)
        {
            _gameBoard = new SquareModel[SIZE, SIZE];
            intToBoard(data);
        }

        public Board DeepCopy()
        {
            Board other = (Board)this.MemberwiseClone();
            other.GameBoard = this.CopyBoard();
            return other;
        }

        private SquareModel[,] CopyBoard()
        {
            SquareModel[,] newBrd = new SquareModel[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    newBrd[i, j] = new SquareModel(GameBoard[i, j].Value, i, j, getGroup(i, j));
                }
            }
            return newBrd;
        }

        private bool verifySizes(int[,] data)
        {
            return true;
        }

        private void intToBoard(int[,] data)
        {
            if (verifySizes(data))
            {
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        GameBoard[i, j] = new SquareModel(data[i, j], i, j, getGroup(i, j));
                    }
                }
            }
        }

        private bool isValidIndex(int i)
        {
            return ((i <= SIZE) && (i > 0));
        }

        private int getGroup(int row, int col)
        {
            return (row / 3 * 3) + (col / 3);
        }

        private void newEmptyBoard(int val)
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    GameBoard[i, j] = new SquareModel(val, i, j, getGroup(i, j));
                }
            }
        }

        public void clearBaord()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    GameBoard[i, j].Value = 0;
                }
            }
        }

        public void printBoard()
        {
            string brd = "";
            string border = "- - - + - - - + - - -\n";
            for (int i = 0; i < SIZE; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    brd += border;
                }
                for (int j = 0; j < SIZE; j++)
                {
                    if (j % 3 == 0 && j != 0)
                    {
                        brd += "| ";
                    }
                    brd += $"{GameBoard[i, j].Value} ";
                }
                brd += '\n';
            }
            UnityEngine.Debug.Log(brd);
        }

        public void setSqaureAt(int row, int col, int val)
        {
            if (!isValidIndex(row) || !isValidIndex(col))
            {
                UnityEngine.Debug.Log($"Invalid index found! {{{row}, {col}}}");
                return;
            }
            GameBoard[row, col].Value = val;
        }

        public void SolveBoard()
        {
            SudokuRules.solveSudoku(this, 0, 0);
        }

        public bool Equal(Board b)
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (this.GameBoard[i, j].Value != b.GameBoard[i, j].Value)
                        return false;
                }
            }
            return true;
        }

        public int GetValueFrom(int row, int col)
        {
            return GameBoard[row, col].Value;
        }
    }
}