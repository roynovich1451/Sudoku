using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public int Value { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public int Group { get; set; }

    public Square() { }

    public Square(int value, int row, int column, int group)
    {
        this.Value = value;
        this.Row = row;
        this.Column = column;
        this.Group = group;
        UnityEngine.Debug.Log(string.Format("Hello, I am Square, my value is {0} at index ({1}, {2}), group {3}", Value, Row, Column, Group));
    }

    public void whoAmI()
    {
        UnityEngine.Debug.Log(string.Format("Hello, I am Square, my value is {0} at index ({1}, {2}), group {3}", Value, Row, Column, Group));
    }

    // Start is called before the first frame update
    void Start()
    {
        //Square s = new Square(1, 1, 1, 1);
        //s.whoAmI(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
