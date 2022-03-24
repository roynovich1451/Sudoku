using UnityEngine;
using TMPro;
using Roy.Sudoku.Model;
using UnityEngine.UI;

namespace Roy.Sudoku.View
{
    public class SquareView : MonoBehaviour
    {
        private TMP_InputField TextField;
        private SquareModel _squareModel;

        // Start is called before the first frame update
        void Start()
        {
            
        }
        /// <summary>
        /// Initialize function for SquareView
        /// </summary>
        /// <param name="squareModel">Relevant Square Model for specific Square</param>
        public void Initialize(SquareModel squareModel)
        {
            AttachObjects();
            _squareModel = squareModel;
            ShowDataToUser(false);
            //Debug.Log($"Initializing {_squareModel.ToString()}");
        }

        /// <summary>
        /// Get needed components for script
        /// </summary>
        private void AttachObjects()
        {
            TextField = transform.gameObject.GetComponent<TMP_InputField>();
        }


        /// <summary>
        /// Display Square data in UI layer
        /// </summary>
        /// <param name="isHint">Is change asked by user as hint</param>
        private void ShowDataToUser(bool isHint)
        {
            Image img = this.transform.GetComponent<Image>();

            if (_squareModel.Value == 0)
                TextField.text = " ";
            else
                TextField.text = _squareModel.Value.ToString();
            if (isHint)
                img.color = new Color32(255, 255, 0, 255);

        }

        private void Clear()
        {
            Image img = this.transform.GetComponent<Image>();

            TextField.text = " ";
            img.color = new Color32(255, 255, 255, 255);
        }
    }
}