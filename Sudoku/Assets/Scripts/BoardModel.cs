using Roy.Sudoku.Common;

namespace Roy.Sudoku.Model
{
    public class BoardModel
    {
        public SquareModel[,] GameBoard { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public BoardModel()
        {
            GameBoard = new SquareModel[Size.BoardSize, Size.BoardSize];
            newEmptyBoard(0);
        }

        /// <summary>
        /// Initial board from 2d array of data
        /// </summary>
        /// <param name="data">2d array of valid integers</param>
        public BoardModel(int[,] data)
        {
            GameBoard = new SquareModel[Size.BoardSize, Size.BoardSize];
            CreateBoardFromData(data);
        }
        /// <summary>
        /// Initialize new board with constant value
        /// </summary>
        /// <param name="val">Valid integer 0-9</param>
        private void newEmptyBoard(int val)
        {
            for (int i = 0; i < Size.BoardSize; i++)
            {
                for (int j = 0; j < Size.BoardSize; j++)
                {
                    GameBoard[i, j] = new SquareModel(val, i, j);
                }
            }
        }


        /// <summary>
        /// Iterate board and clear all data
        /// </summary>
        public void clearBaord()
        {
            for (int i = 0; i < Size.BoardSize; i++)
            {
                for (int j = 0; j < Size.BoardSize; j++)
                {
                    GameBoard[i, j].ClearSquareData();
                }
            }
        }
        
        /// <summary>
        /// Deep copy for board model
        /// </summary>
        /// <returns>New identical instance of BoardModel</returns>
        public BoardModel DeepCopy()
        {
            BoardModel other = (BoardModel)this.MemberwiseClone();
            other.GameBoard = this.CopyBoard();
            return other;
        }

        /// <summary>
        /// Create new 2d array of SquareModel identical to the one BoardModel has
        /// </summary>
        /// <returns>2d array of SquareModel</returns>
        private SquareModel[,] CopyBoard()
        {
            SquareModel[,] newBrd = new SquareModel[Size.BoardSize, Size.BoardSize];

            for (int i = 0; i < Size.BoardSize; i++)
            {
                for (int j = 0; j < Size.BoardSize; j++)
                {
                    newBrd[i, j] = new SquareModel(GameBoard[i, j].Value, i, j);
                }
            }
            return newBrd;
        }

        /// <summary>
        /// Create new board using given 2d array of integers
        /// </summary>
        /// <param name="data">2d array of integers</param>
        private void CreateBoardFromData(int[,] data)
        {
            for (int i = 0; i < Size.BoardSize; i++)
            {
                for (int j = 0; j < Size.BoardSize; j++)
                {
                    GameBoard[i, j] = new SquareModel(data[i, j], i, j);
                }
            }
        }

        /// <summary>
        /// Set square value at specific index
        /// </summary>
        /// <param name="row">Valid row number</param>
        /// <param name="col">Valid col number</param>
        /// <param name="val">Valid Value</param>
        public void SetSqaureDataByIndex(int row, int col, int val)
        {
            GameBoard[row, col].Value = val;
        }

        /// <summary>
        /// Get square value at specific index
        /// </summary>
        /// <param name="row">Valid row number</param>
        /// <param name="col">Valid col number</param>
        /// <returns>Value as integer</returns>
        public int GetSquareDataByIndex(int row, int col)
        {
            return GameBoard[row, col].Value;
        }

        public int[,] ConvertGameBoardTo2DInteger()
        {
            int[,] intArray = new int[Size.BoardSize, Size.BoardSize];

            for (int i = 0; i < Size.BoardSize; i++)
            {
                for (int j = 0; j < Size.BoardSize; j++)
                {
                    intArray[i, j] = GetSquareDataByIndex(i, j);
                }
            }
            return intArray;
        }

        /// <summary>
        /// Check if two BoardModels are equal
        /// </summary>
        /// <param name="b">Another BoardModel for comprehension</param>
        /// <returns>Boolean yes/no if equal</returns>
        public bool isEqual(BoardModel b)
        {
            for (int i = 0; i < Size.BoardSize; i++)
            {
                for (int j = 0; j < Size.BoardSize; j++)
                {
                    if (this.GameBoard[i, j].Value != b.GameBoard[i, j].Value)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Get SquareModel by given valid index.
        /// Way of calculation: index -> Square[,] -> Square[row, column]
        /// Example (4X4):
        /// {  0,  1,  2,  3},
        /// {  4,  5,  6,  7},
        /// {  8,  9, 10, 11},
        /// { 12, 13, 14, 15}
        /// </summary>
        /// <param name="index">valid array index (0-Size.BoardSize^2)</param>
        /// <returns>Coresponding SquareModel</returns>
        public SquareModel GetSquareModelFromIndex(int index)
        {
            int[] indexes = IndexingArrayTo2dArray(index);

            return GameBoard[indexes[Defines.RowIndex], indexes[Defines.ColumnIndex]];
        }

        /// <summary>
        /// Get SquareModel by given valid index. 
        /// Way of calculation: index -> groups[] -> Square[row, column]
        /// Example (4X4):
        /// {  0,  1,  4,  5},
        /// {  2,  3,  6,  7},
        /// {  8,  9, 12, 13},
        /// { 10, 11, 14, 15}
        /// </summary>
        /// <param name="index">valid array index (0-Size.BoardSize^2)</param>
        /// <returns>Coresponding SquareModel</returns>
        public SquareModel GetSquareModelFromIndexByGroup(int index)
        {
            int[] indexes = IndexingArrayTo2dArrayGroups(index);

            return GameBoard[indexes[Defines.RowIndex], indexes[Defines.ColumnIndex]];
        }

        /// <summary>
        /// Calculate 2d array index into array index
        /// </summary>
        /// <param name="row">Valid row number</param>
        /// <param name="col">Valid column number</param>
        /// <returns></returns>
        public int Indexing2dArrayToArray(int row, int col)
        {
            return (row * Size.BoardSize) + col;
        }

        public int[] IndexingArrayTo2dArray(int index)
        {
            return new int[]
            {
                index /  Size.BoardSize,
                index % Size.BoardSize
            };
        }

        public int[] IndexingArrayTo2dArrayGroups(int index)
        {

            int[] groupStartIndexes = GetStartIndexesGroups(index);
            int difference = GetDifferecneBeteweenIndexToStartOfHisGroup(index);
            int[] insideGroupDifference = IndexingInsideGroup(difference);

            return new int[]
            {
                groupStartIndexes[Defines.RowIndex] + insideGroupDifference[Defines.RowIndex],
                groupStartIndexes[Defines.ColumnIndex] + insideGroupDifference[Defines.ColumnIndex]
            };
        }
        public int GetDifferecneBeteweenIndexToStartOfHisGroup(int index)
        {
            return index - (index / Size.BoardSize * Size.BoardSize);
        }
        public int[] IndexingInsideGroup(int index)
        {
            return new int[]
            {
                index / Size.GroupSize,
                index % Size.GroupSize
            };
        }
      
        public int[] GetStartIndexesGroups(int index)
        {
            int group = index / Size.NumberOfGroups;

            int startRow = (group / Size.GroupSize) * Size.GroupSize;
            int startColumn = (group % Size.GroupSize) * Size.GroupSize;

            return new int[]
            {
                startRow,
                startColumn
            };
        }

        
        /* Need to move into controller
        public void SolveBoard()
        {
            SudokuRules.solveSudoku(this, 0, 0);
        }
        */
        /*
       private bool isValidIndex(int i)
       {
           return ((i <= SIZE) && (i > 0));
       }

       private int getGroup(int row, int col)
       {
           return (row / 3 * 3) + (col / 3);
       }
       */


        /*
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
        */
    }
}