using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roy.Sudoku.Model
{
    public class SquareModel
    {
        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value < 0 || value > Board.SIZE + 1)
                {
                    throw new ArgumentException($"Invalid value {value}, Do nothing.");
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
                    throw new ArgumentException($"Invalid row index {value}, Do nothing.");
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

        public SquareModel() { }

        public SquareModel(int value, int row, int column, int group)
        {
            this.Value = value;
            this.Row = row;
            this.Column = column;
            this.Group = group;
            //UnityEngine.Debug.Log(string.Format("Hello, I am Square, my value is {0} at index ({1}, {2}), group {3}", Value, Row, Column, Group));
        }

        override
        public string ToString()
        {
            return $"({Row}, {Column}) = {Value}";
        }
    }
}