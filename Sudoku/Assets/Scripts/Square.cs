using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square
{
    private int _value;
    public int Value {
        get
        {
            return _value;
        }
        set
        {
            if (value < 0 || value > Board.SIZE + 1)
            {
                UnityEngine.Debug.Log($"Invalid value {value}, Do nothing.");
                return;
            }
            _value = value;
        } 
    }

    private int _row;
    public int Row
    {
        get
        {
            return _row;
        }
        set
        {
            if (value < 0 || value > Board.SIZE)
            {
                UnityEngine.Debug.Log($"Invalid row index {value}, Do nothing.");
                return;
            }
            _row = value;
        }
    }

    private int _column;
    public int Column
    {
        get
        {
            return _column;
        }
        set
        {
            if (value < 0 || value > Board.SIZE)
            {
                UnityEngine.Debug.Log($"Invalid column index {value}, Do nothing.");
                return;
            }
            _column = value;
        }
    }

    private int _group;
    public int Group
    {
        get
        {
            return _group;
        }
        set
        {
            if (value < 0 || value > Board.SIZE)
            {
                UnityEngine.Debug.Log($"Invalid group {value}, Do nothing.");
                return;
            }
            _group = value;
        }
    }

    public Square() { }

    public Square(int value, int row, int column, int group)
    {
        this.Value = value;
        this.Row = row;
        this.Column = column;
        this.Group = group;
        //UnityEngine.Debug.Log(string.Format("Hello, I am Square, my value is {0} at index ({1}, {2}), group {3}", Value, Row, Column, Group));
    }

    public void ToString()
    {
        UnityEngine.Debug.Log(string.Format("Hello, I am Square, my value is {0} at index ({1}, {2}), group {3}", Value, Row, Column, Group));
    }
}
