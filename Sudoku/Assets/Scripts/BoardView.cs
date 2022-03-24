using UnityEngine;
using Roy.Sudoku.Model;
using Roy.Sudoku.View;
using Roy.Sudoku.Common;

namespace Roy.Sudoku.View
{
   public class BoardView : MonoBehaviour
    {
        private BoardModel _boardModel;
        private SquareView[] _squareViews;
        
        public void Initialize(BoardModel boardModel)
        {
            _boardModel = boardModel;
            AttachObjects();
            InitialAllSquareModels();
        }

        public void AttachObjects()
        {
            _squareViews = GetComponentsInChildren<SquareView>();
        }

        public void InitialAllSquareModels()
        {
            int arrayLength = _squareViews.Length;
            //Debug.Log($"_squareViews.Length = {_squareViews.Length}");

            /*for (int index = 0; index < ArrayLength; index++)
            {
                int[] indexes = IndexingArrayTo2dArray(index);
                int row = indexes[Defines.RowIndex];
                int col = indexes[Defines.ColumnIndex];

                _squareViews[index].Initialize(_boardModel.GetSquareModelFromIndex(row, col));
            }*/
            for (int index = 0; index < arrayLength; index++)
            {
                if (index == 27)
                {
                    bool a = true;
                }
                _squareViews[index].Initialize(_boardModel.GetSquareModelFromIndexByGroup(index));
            }
        }
    }

}
