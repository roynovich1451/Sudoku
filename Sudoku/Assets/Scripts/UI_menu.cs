using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_menu : MonoBehaviour
{
    private Button newButton;
    private Button hintButton;
    private Game _gameScript;

    // Start is called before the first frame update
    void Start()
    {
        AttachObjects();
    }

    private void AttachObjects()
    {
        newButton = transform.Find("newBtn").GetComponent<Button>();
        hintButton = transform.Find("hintBtn").GetComponent<Button>();
        newButton.onClick.AddListener(delegate { NewGame(); });
        hintButton.onClick.AddListener(delegate { GiveMeHint(); });
        _gameScript = GameObject.Find("Module").GetComponent<Game>();
    }

    public void NewGame()
    {
        Debug.Log($"Player want to start new game!");
        _gameScript.StartNewGame();
    }

    public void GiveMeHint()
    {
        Debug.Log($"Player want to get a hint!");
        _gameScript.HintPlease();
    }
}
