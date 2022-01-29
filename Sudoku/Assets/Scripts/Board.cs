using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private const int SIZE = 9;
    private Square[,] _board = new Square[SIZE, SIZE];

    private bool isValidIndex(int i)
    {
        return ((i < SIZE) && (i >= 0));
    }

    private int getGroup(int row, int col)
    {
        return (row / 3 * 3) + (col / 3);
    }

    private void setSquaresLocations()
    {
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                _board[i, j] = new Square(1, i, j, getGroup(i, j));
            }
        }
    }

    public void clearBaord()
    {
        for (int i = 0; i < SIZE; i++)
        {
            for (int j = 0; j < SIZE; j++)
            {
                _board[i, j].Value = 0;
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
                brd += $"{_board[i, j].Value} :";  
            }
            brd += '\n';
        }
        UnityEngine.Debug.Log(brd);
    }

    public void setSqaureAt(int row, int col, int val)
    {
        if (!isValidIndex(row) || !isValidIndex(col) || !isValidIndex(val))
        {
            UnityEngine.Debug.Log($"Invalid index found! {row} {col} {val}");
            return;
        }
        _board[row, col].Value = val;
    }
    // Start is called before the first frame update
    void Start()
    {
        setSquaresLocations();
        printBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
