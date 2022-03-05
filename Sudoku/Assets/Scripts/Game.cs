using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using TMPro;
using Random = System.Random;
using UnityEngine.UI;
using Roy.Sudoku.Model;
using Roy.Sudoku.View;

namespace Roy.Sudoku.Controllers
{
    public class Game : MonoBehaviour
    {
        private Board currentBoard;
        private Board solution;
        private string ID;
        [SerializeField] private int availableHints = 5;

        void Start()
        {

        }

        public void StartNewGame()
        {
            ID = GenerateID();
            currentBoard = new Board(GenerateBoardData());
            solution = currentBoard.DeepCopy();
            solution.SolveBoard();
            DisplayBoard();
            DisplayID();
        }

        private void DisplayID()
        {
            GameObject id = GameObject.Find("gameID");
            id.GetComponentInChildren<Text>().text = $"Game ID: {ID}";
        }

        internal void HintPlease()
        {
            int i, j, hint;
            Random r = new Random();

            if (availableHints == 0)
            {
                Debug.Log($"No more hints available!");
                return;
            }

            do
            {
                i = r.Next(0, Board.SIZE);
                j = r.Next(0, Board.SIZE);
            } while (currentBoard.GetValueFrom(i, j) != 0);
            hint = solution.GetValueFrom(i, j);
            DisplaySquare(hint, i, j);

            availableHints--;
            Debug.Log($"{availableHints} hints still available!");
        }

        private void DisplaySquare(int val, int row, int col)
        {
            string search = $"s{row}{col}";
            GameObject board = GameObject.Find("Board");

            foreach (Transform group in board.transform)
            {
                foreach (Transform square in group.transform)
                {
                    if (square.name == search &&
                        square.gameObject.TryGetComponent<UI_square>(out UI_square sq))
                    {
                        sq.Display(val, true);
                    }
                }
            }
        }
        private void DisplayBoard()
        {
            GameObject board = GameObject.Find("Board");

            foreach (Transform group in board.transform)
            {
                foreach (Transform square in group.transform)
                    if (square.gameObject.TryGetComponent<UI_square>(out UI_square sq))
                    {
                        Debug.Log($"child name = {sq.name}");
                        sq.DisplayFromBoard(currentBoard);
                    }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void UpdateMove(string val, int row, int col)
        {
            //TODO: check input vak;
            int v = Int32.Parse(val);
            Debug.Log($"updating! {val} -> ({row}, {col})");
            currentBoard.GameBoard[row, col].Value = v;
            CheckFinished();
        }

        public string GetValue(int row, int col)
        {
            return currentBoard.GameBoard[row, col].Value.ToString();
        }

        public bool IsGameEnd()
        {
            for (int i = 0; i < Board.SIZE; i++)
            {
                for (int j = 0; j < Board.SIZE; j++)
                {
                    if (currentBoard.GameBoard[i, j].Value == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsCorrectSolution()
        {
            return solution.Equal(currentBoard);
        }

        public void CheckFinished()
        {
            if (IsGameEnd())
            {
                if (!IsCorrectSolution())
                {
                    Debug.Log($"GAME END - YOU HAVE SOME MISTAKES...");
                }
                else
                {
                    Debug.Log($"GAME END - YOU WIN!!!");
                }
            }
        }

        private string GenerateID()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(8)
                .ToList().ForEach(e => builder.Append(e));
            return builder.ToString();
        }

        private int[,] GenerateBoardData()
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
    }
}