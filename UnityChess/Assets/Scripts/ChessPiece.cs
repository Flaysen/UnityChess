using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    [SerializeField]
    private string _name;
    public string Name => _name; 
    public bool Moved { get; set; }

    private void Awake()
    {
    
    }
    
    public virtual List<Vector3> GetMoves()
    {
        List<Vector3> possibleMoves = new List<Vector3>();

        possibleMoves.Add(new Vector3(0, 0, 1) + transform.position);
        if(!Moved) possibleMoves.Add(new  Vector3(0, 0, 2) + transform.position);

        return possibleMoves;
    } 

    public void Move()
    {

    }
}
