using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class SudokuRules
{
    public const int SIZE = Board.SIZE;
    public const int ROW = 0;
    public const int COL = 1;

    public static bool checkUniqueness(Square brd, int row, int col, int val, bool is_row)
    {
        for (int i = 0; i < SIZE; i++)
        {
            if (is_row)
            {
                if (brd.Value == val)
                    return false;
            } 
            else
            {
                if (brd.Value == val)
                    return false;
            }
            
        }
        return true;
    }

    public static bool checkGroupUniqueness(Square[,] arr, int group, int val)
    {
        int[] indexes = getStartIndexes(group);
        UnityEngine.Debug.Log($"Checking indexes: {{{indexes[ROW]}, {indexes[COL]}}}");
        for (int i = indexes[ROW]; i < Board.GROUP_SIZE && i < Board.SIZE; i++)
        {
            for (int j = indexes[COL]; i < Board.GROUP_SIZE && j < Board.SIZE; j++)
            {
                UnityEngine.Debug.Log($"Checking indexes: {{{i}, {j}}}");
                if (arr[i, j].Value == val)
                {
                    UnityEngine.Debug.Log($"Invalid {val} is not uniqe: {{{i}, {j}}}");
                    return false;
                }
            }
        }
        return true;
    }

    private static int[] getStartIndexes(int group)
    {
        return new int[] 
        {
            group / Board.GROUP_SIZE * Board.GROUP_SIZE,
            group % Board.GROUP_SIZE * Board.GROUP_SIZE
        };
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
}
