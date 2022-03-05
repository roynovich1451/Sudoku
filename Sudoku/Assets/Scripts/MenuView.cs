using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuView : MonoBehaviour
{
    [SerializeField]
    private Button newButton;
    [SerializeField]
    private Button hintButton;

    // Start is called before the first frame update
    void Start()
    {
        AttachObjects();
    }

    private void AttachObjects()
    {
        newButton.onClick.AddListener(delegate { NewGame(); });
        hintButton.onClick.AddListener(delegate { GiveMeHint(); });
        //_gameScript = GameObject.Find("Module").GetComponent<Game>();
    }

    public void NewGame()
    {
        Debug.Log($"Player want to start new game!");
        //_gameScript.StartNewGame();
    }

    public void GiveMeHint()
    {
        Debug.Log($"Player want to get a hint!");
        //_gameScript.HintPlease();
    }
}
