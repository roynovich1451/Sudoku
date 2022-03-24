using System;
using Roy.Sudoku.Common;

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
                if (value < Validation.ValidInputLow || value > Validation.ValidInputHigh)
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
                if (value < 0 || value > Size.BoardSize)
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
                if (value < 0 || value > Size.BoardSize)
                {
                    UnityEngine.Debug.Log($"Invalid column index {value}, Do nothing.");
                    return;
                }
                _column = value;
            }
        }

        public void ClearSquareData()
        {
            Value = 0;
        }

        public SquareModel() { }

        public SquareModel(int value, int row, int column)
        {
            this.Value = value;
            this.Row = row;
            this.Column = column;
        }

        override
        public string ToString()
        {
            return $"{Value.ToString()} at ({Row}, {Column})";
        }
    }
}