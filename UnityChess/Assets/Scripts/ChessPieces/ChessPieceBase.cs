using System.Collections.Generic;
using UnityEngine;

public class ChessPieceBase : MonoBehaviour
{
    [SerializeField]
    private string _name;
    public string Name => _name; 
    public bool Moved { get; set; }
    private Board _board;

    private void Start()
    {
        RegisterPieceOnBoard();
    }

    private void RegisterPieceOnBoard()
    {
        _board = FindObjectOfType<Board>();
        _board.ChessPieces.Add(this);
    }
    
    public virtual List<Vector3> GetMoves() => null;

    protected List<Vector3> GetMovesInDirection(Vector3 direction, float range)
    {
        List<Vector3> possibleMoves = new List<Vector3>();

        for(int distance = 1; distance <= range; distance++ )
        {   
            Vector3 position = (direction * distance) + transform.position;
            if(_board.CheckIfPositionOccupied(position) || _board.CheckIfPositionOutOfBoard(position))
            {
               break;
            }
            possibleMoves.Add(position);         
        }

        return possibleMoves;
    }
}
