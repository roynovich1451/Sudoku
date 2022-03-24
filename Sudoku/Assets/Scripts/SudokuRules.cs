using Roy.Sudoku.Model;
using Roy.Sudoku.Common;

namespace Roy.Sudoku.Static
{
    static class SudokuRules
    {
        /// <summary>
        /// Validate new data is unique over row/column
        /// </summary>
        /// <param name="brd">2d array of integers</param>
        /// <param name="row">Valid row number</param>
        /// <param name="col">Valid col number</param>
        /// <param name="val">Valid data number</param>
        /// <param name="is_row">boolean - true if need to check row false otherwise</param>
        /// <returns>Boolean indication if valid row/column assignment</returns>
        public static bool checkUniqueness(int[,] brd, int row, int col, int val, bool is_row)
        {
            for (int i = 0; i < Size.BoardSize; i++)
            {
                if (is_row)
                {
                    if (brd[row, i] == val)
                        return false;
                }
                else
                {
                    if (brd[i, col] == val)
                        return false;
                }

            }
            return true;
        }

        /// <summary>
        /// Calculate the starting index of a group need to be checked
        /// </summary>
        /// <param name="row">Valid row number</param>
        /// <param name="col">Valid col number</param>
        /// <returns>First element is row index, second is column index</returns>
        private static int[] GetStartIndexForGroupUniqness(int row, int col)
        {
            return new int[]
            {
                row - row %  Size.GroupSize,
                col - col % Size.GroupSize
            };
        }

        /// <summary>
        /// Validate new data is unique over row/column
        /// </summary>
        /// <param name="brd">2d array of integers</param>
        /// <param name="row">Valid row number</param>
        /// <param name="col">Valid col number</param>
        /// <param name="val">Valid data number</param>
        /// <returns>Boolean indication if valid group assignment</returns>
        public static bool checkGroupUniqueness(int[,] brd, int row, int col, int val)
        {
            int[] indexes = GetStartIndexForGroupUniqness(row, col);

            for (int i = indexes[Defines.RowIndex]; i < Size.GroupSize; i++)
            {
                for (int j = indexes[Defines.ColumnIndex]; j < Size.GroupSize; j++)
                {
                    if (brd[i, j] == val)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Colaborate all validations needed for new data over Sudoku game
        /// </summary>
        /// <param name="brd">2d array of integers</param>
        /// <param name="row">Valid row number</param>
        /// <param name="col">Valid col number</param>
        /// <param name="num">Valid data number</param>
        /// <returns>Boolean indication if valid Sudoku move</returns>
        public static bool isLegalAssignment(int[,] brd, int row, int col, int num)
        {
            return SudokuRules.checkGroupUniqueness(brd, row, col, num) &&
                SudokuRules.checkUniqueness(brd, row, col, num, true) &&
                SudokuRules.checkUniqueness(brd, row, col, num, false);
        }

        /// <summary>
        /// Recursivly Solving of given Sudoku board
        /// </summary>
        /// <param name="brd">2d array of integers</param>
        /// <param name="row">Current row solving</param>
        /// <param name="col">Current column solving</param>
        /// <returns>Boolean indecation if move is correct</returns>
        public static bool solveSudoku(int[,] brd, int row, int col)
        {

            if (row == Size.BoardSize - 1 && col == Size.BoardSize)
                return true;

            if (col == Size.BoardSize)
            {
                col = 0;
                row++;
            }

            if (brd[row, col] > 0)
                return solveSudoku(brd, row, col + 1);

            for (int num = 1; num <= Size.BoardSize; num++)
            {
                if (SudokuRules.isLegalAssignment(brd, row, col, num))
                {
                    brd[row, col] = num;
                    if (solveSudoku(brd, row, col + 1))
                        return true;
                }
                brd[row, col] = 0;
            }
            return false;
        }

        public static int[,] GenerateNewBoard()
        {
            int[,] data = {
                { 3, 0, 6, 5, 0, 8, 4, 0, 0 },
                { 5, 2, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 8, 7, 0, 0, 0, 0, 3, 1 },
                { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
                { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
                { 0, 5, 0, 0, 9, 0, 6, 0, 0 },
                { 1, 3, 0, 0, 0, 0, 2, 5, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
                { 0, 0, 5, 2, 0, 6, 3, 0, 0 }
            };

            //TODO: actual implement board generator;
            return data;
        }
        /*
       public static void printArray(int[] arr)
       {
           string pArr = "";
           for (int i = 0; i < Size.BoardSize; i++)
           {
               pArr += arr[i];
           }
           UnityEngine.Debug.Log(pArr);
       }
       */
    }
}