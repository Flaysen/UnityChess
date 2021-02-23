using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    [SerializeField]
    private string _name;
    public string Name => _name; 
    public bool Moved { get; set; }
    public Board Board;

    private void Start()
    {
        Board = FindObjectOfType<Board>();
        Board.ChessPieces.Add(this);
        //Debug.Log(string.Format("{0} : {1}", piece.Name, piece.transform.position));
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
    protected List<Vector3> GetMovesInDirection(Vector3 direction, float range)
    {
        List<Vector3> possibleMoves = new List<Vector3>();

        for(int distance = 1; distance <= range; distance++ )
        {   
            Vector3 position = (direction * distance) + transform.position;
            if(Board.CheckIfPositionOccupied(position) || Board.CheckIfPositionOutOfBoard(position))
            {
               break;
            }
            possibleMoves.Add(position);         
        }

        return possibleMoves;
    }
}
