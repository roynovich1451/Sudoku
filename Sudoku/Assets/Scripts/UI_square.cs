using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_square : MonoBehaviour
{
    private Game _gameScript;
    private TMP_InputField input;
    private string objName;
    private int Row { get; set; }
    private int Col { get; set; }
    private String currentval;

    // Start is called before the first frame update
    void Start()
    {
        AttachObjects();
        objName = input.name;
        input.onValueChanged.AddListener(delegate { ValueChange(); });
        Row = Int32.Parse(objName[1].ToString());
        Col = Int32.Parse(objName[2].ToString());
        input.text = " ";
    }

    private void ValueChange()
    {
        input.text = input.text.Trim();
        currentval = _gameScript.GetValue(Row, Col);
        try
        {
            _gameScript.UpdateMove(input.text, Row, Col);
            currentval = input.text;
        }
        catch (ArgumentException ex)
        {
            Debug.Log($"EXCEPTION: {ex.Message}");
            input.text = currentval;
        }
    }

    private void AttachObjects()
    {
        _gameScript = GameObject.Find("Module").GetComponent<Game>();
        input = transform.gameObject.GetComponent<TMP_InputField>();
    }

    public void DisplayFromBoard(Board brd)
    {
        Image img = this.transform.GetComponent<Image>();

        int val = brd.GetValueFrom(Row, Col);
        if (val != 0)
            input.text = val.ToString();
        else
            input.text = " ";
        img.color = new Color32(255, 255, 255, 255);
    }

    public void Display(int val, bool isHint)
    {
        Image img = this.transform.GetComponent<Image>();
        
        input.text = val.ToString();
        if (isHint)
            img.color = new Color32(248, 240, 0, 255);
    }
}
