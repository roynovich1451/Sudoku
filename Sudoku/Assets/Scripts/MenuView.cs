using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
    [SerializeField]
    private Button newButton;
    [SerializeField]
    private Button hintButton;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: OPEN AttachObjects();
    }

    private void AttachObjects()
    {
        newButton.onClick.AddListener(delegate { NewGame(); });
        hintButton.onClick.AddListener(delegate { GetHint(); });
        //_gameScript = GameObject.Find("Module").GetComponent<GameController>();
    }

    public void NewGame()
    {
        Debug.Log($"Player want to start new game!");
        //_gameScript.StartNewGame();
    }

    public void GetHint()
    {
        Debug.Log($"Player want to get a hint!");
        //_gameScript.HintPlease();
    }
}
