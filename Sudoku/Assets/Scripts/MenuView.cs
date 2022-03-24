using UnityEngine;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
    [SerializeField]
    private Button newButton;
    [SerializeField]
    private Button hintButton;

    public delegate void NewGameButtonClickedEventHandler();

    public event NewGameButtonClickedEventHandler NewGameButtonClicked;
    

    public delegate void HintButtonClickedEventHandler();

    public event HintButtonClickedEventHandler HintButtonClicked;
  
    // Start is called before the first frame update
    void Start()
    {
        AddListeners();
    }

    public void Initialize(NewGameButtonClickedEventHandler newGameHandler, HintButtonClickedEventHandler hintHandler)
    {
        NewGameButtonClicked += newGameHandler;
        HintButtonClicked += hintHandler;
    }

    private void AddListeners()
    {
        newButton.onClick.AddListener(delegate { NewGameButtonClicked(); });
        hintButton.onClick.AddListener(delegate { HintButtonClicked(); });
    }
    /*
    protected virtual void OnNewGameButtonClicked()
    {
        System.Console.WriteLine($"OnMenuButtonClick just clicked");
        if (NewGameButtonClicked != null)
            NewGameButtonClicked();
    }

    protected virtual void OnHintButtonClicked()
    {
        System.Console.WriteLine($"OnMenuButtonClick just clicked");
        if (HintButtonClicked != null)
            HintButtonClicked();
    }
    */
}
