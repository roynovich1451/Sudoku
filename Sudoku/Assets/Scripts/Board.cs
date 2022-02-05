using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    public const int SIZE = 9;
    public const int GROUP_SIZE = 3;

    private Square[,] _gameBoard;
    public Square[,] GameBoard
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
        _gameBoard = new Square[SIZE, SIZE];
        newEmptyBoard(0);
    }

    public Board(Square[,] brd)
    {
        GameBoard = brd;
    }

    private bool isValidIndex(int i)
    {
        return ((i < SIZE) && (i >= 0));
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
                GameBoard[i, j] = new Square(val, i, j, getGroup(i, j));
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
        if (SudokuRules.)
        GameBoard[row, col].Value = val;
    }
}
