using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class SudokuRules
{
    public const int SIZE = Board.SIZE;
    public const int ROW = 0;
    public const int COL = 1;

    public static bool checkUniqueness(Board brd, int row, int col, int val, bool is_row)
    {
        for (int i = 0; i < SIZE; i++)
        {
            if (is_row)
            {
                if (brd.GameBoard[row, i].Value == val)
                    return false;
            }
            else
            {
                if (brd.GameBoard[i, col].Value == val)
                    return false;
            }

        }
        return true;
    }

    private static int[] getStartIndexes(int row, int col)
    {
        return new int[]
        {
            row - row % Board.GROUP_SIZE,
            col - col % Board.GROUP_SIZE
        };
    }

    public static bool checkGroupUniqueness(Board brd, int row, int col, int val)
    {
        int[] indexes = getStartIndexes(row, col);
        //UnityEngine.Debug.Log($"Checking indexes: {{{indexes[ROW]}, {indexes[COL]}}}");
        for (int i = indexes[ROW]; i < Board.GROUP_SIZE; i++)
        {
            for (int j = indexes[COL]; j < Board.GROUP_SIZE; j++)
            {
                if (brd.GameBoard[i, j].Value == val)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static void printArray(Square[] arr)
    {
        string pArr = "";
        for (int i = 0; i < SIZE; i++)
        {
            pArr += arr[i].Value;
        }
        UnityEngine.Debug.Log(pArr);
    }

    public static bool isLegalAssignment(Board brd, int row, int col, int num)
    {
        return SudokuRules.checkGroupUniqueness(brd, row, col, num) &&
            SudokuRules.checkUniqueness(brd, row, col, num, true) &&
            SudokuRules.checkUniqueness(brd, row, col, num, false);
    }

    public static bool solveSudoku(Board brd, int row, int col)
    {
        UnityEngine.Debug.Log($"solve index {{{row}, {col}}}");

        if (row == Board.SIZE - 1 && col == Board.SIZE)
            return true;

        if (col == Board.SIZE)
        {
            col = 0;
            row++;
        }

        if (brd.GameBoard[row, col].Value > 0)
            return solveSudoku(brd, row, col + 1);

        for (int num = 1; num <= Board.SIZE; num++)
        {
            if (SudokuRules.isLegalAssignment(brd, row, col, num))
            {
                brd.GameBoard[row, col].Value = num;
                if (solveSudoku(brd, row, col + 1))
                    return true;
            }
            brd.GameBoard[row, col].Value = 0;
        }
        return false;
    }
}