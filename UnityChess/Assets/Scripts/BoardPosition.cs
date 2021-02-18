using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPosition 
{
    public Vector3 Postition { get; private set; }
    public ChessPiece ChessPiece { get; set; }   
    
    public BoardPosition(Vector3 position)
    {
        Postition = position;
    }
}
