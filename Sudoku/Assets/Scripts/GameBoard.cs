using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Board b = new Board();
        b.setSqaureAt(1,2,5);
        SudokuRules.checkGroupUniqueness(b.GameBoard, 0, 4);
        b.printBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
