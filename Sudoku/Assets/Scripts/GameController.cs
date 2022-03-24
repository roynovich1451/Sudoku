
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
using Roy.Sudoku.Model;
using Roy.Sudoku.View;
using Roy.Sudoku.Static;
using Roy.Sudoku.Common;
using System;

namespace Roy.Sudoku.Controllers
{
    public class GameController : MonoBehaviour
    {
        private MenuView _menu;
        private BoardView _boardView;
        private BoardModel _currentBoard;
        private BoardModel _solution;
        private string ID;
        [SerializeField] private int availableHints = 5;

        /*
        public delegate void SquareValueChangedEventHandler(object source, Event args);

        public event SquareValueChangedEventHandler SquareValueChanged;
        
        protected virtual void OnSquareValueChanged()
        {
            if (SquareValueChanged != null)
                SquareValueChanged(this, Event.current);
        }
        */
        public delegate void MenuButtonClickEventHandler(object source, Event e);

        public event MenuButtonClickEventHandler MenuButtonClicked;
        protected virtual void OnMenuButtonClick()
        {
            System.Console.WriteLine($"OnMenuButtonClick just clicked");
            /*
            if (MenuButtonClicked != null)
                MenuButtonClicked(this, Event.current);
            */
        }

        void Start()
        {
            /*
            ID = Generators.GenerateRandomStringWithLength(Defines.IdLength);
            CreateGameModels();
            AttachGameViews();
            InitializeGame(_currentBoard);
            */

            AttachGameViews();
            _menu.Initialize(StartNewGame, getHint);
        }

        public void StartNewGame()
        {
            ID = Generators.GenerateRandomStringWithLength(Defines.IdLength);
            CreateGameModels();
            InitializeGame(_currentBoard);
        }

        private void CreateGameModels()
        {
            _currentBoard = new BoardModel(SudokuRules.GenerateNewBoard());
            _solution = GetSolution(_currentBoard);
        }
        private void AttachGameViews()
        {
            _menu = gameObject.GetComponentInChildren<MenuView>();
            _boardView = gameObject.GetComponentInChildren<BoardView>();
        } 
      
        public BoardModel GetSolution(BoardModel brd)
        {
            int[,] intBoard = brd.ConvertGameBoardTo2DInteger();

            if (SudokuRules.solveSudoku(intBoard, 0, 0))
            {
                return new BoardModel(intBoard);
            }
            else
            {
                //TODO: Handle Can't solve board
                return null;
            }
        }

        public void InitializeGame(BoardModel brd)
        {
            _boardView.Initialize(brd);
        }

        private void getHint()
        {
            /* TODO: Deal which displaying the hint
            int i, j, hint;
            Random r = new Random();

            if (availableHints == 0)
            {
                Debug.Log($"No more hints available!");
                return;
            }

            do
            {
                i = r.Next(0, Size.BoardSize);
                j = r.Next(0, Size.BoardSize);
            } while (_currentBoard.GetSquareDataByIndex(i, j) != 0);
            hint = _solution.GetSquareDataByIndex(i, j);
            _currentBoard.SetSqaureDataByIndex(hint, i, j);

            availableHints--;
            Debug.Log($"{availableHints} hints still available!");
            */
        }

        /*
        private void DisplayID()
        {
            GameObject id = GameObject.Find("gameID");
            id.GetComponentInChildren<Text>().text = $"GameController ID: {ID}";
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
                i = r.Next(0, BoardModel.SIZE);
                j = r.Next(0, BoardModel.SIZE);
            } while (currentBoard.GetValueFrom(i, j) != 0);
            hint = solution.GetValueFrom(i, j);
            DisplaySquare(hint, i, j);

            availableHints--;
            Debug.Log($"{availableHints} hints still available!");
        }

        private void DisplaySquare(int val, int row, int col)
        {
            string search = $"s{row}{col}";
            GameObject board = GameObject.Find("BoardModel");

            foreach (Transform group in board.transform)
            {
                foreach (Transform square in group.transform)
                {
                    if (square.name == search &&
                        square.gameObject.TryGetComponent<SquareView>(out SquareView sq))
                    {
                        sq.Display(val, true);
                    }
                }
            }
        }
        private void DisplayBoard()
        {
            GameObject board = GameObject.Find("BoardModel");

            foreach (Transform group in board.transform)
            {
                foreach (Transform square in group.transform)
                    if (square.gameObject.TryGetComponent<SquareView>(out SquareView sq))
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
            for (int i = 0; i < BoardModel.SIZE; i++)
            {
                for (int j = 0; j < BoardModel.SIZE; j++)
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

        

        
        */
    }
}