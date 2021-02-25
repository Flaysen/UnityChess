using System.Collections.Generic;
using UnityEngine;

public class ChessPieceBase : MonoBehaviour
{
    [SerializeField] protected PiecesColor _color;
    [SerializeField] private string _name; 
    public bool Moved { get; set; }
    public string Name => _name; 
    public PiecesColor Color => _color;
    private MoveHandler _moveHandler;

    private Board _board;

    private void Start()
    {      
        _moveHandler = FindObjectOfType<MoveHandler>();
        _moveHandler.OnCapture += DisableOnCapture;
        RegisterPieceOnBoard(this);
    }
    
    protected void RegisterPieceOnBoard(ChessPieceBase chessPiece)
    {
        _board = FindObjectOfType<Board>();
        _board.ChessPieces.Add(this);
    }

    public void SetColor(PiecesColor color) 
    {
        _color = color;
    }
    
    public virtual List<Vector3> GetMoves() => null;

    protected List<Vector3> GetMovesInDirection(Vector3 direction, float range, bool isPawnMove = false, bool canNotCapture = false)
    {
        List<Vector3> possibleMoves = new List<Vector3>();

        for(int distance = 1; distance <= range; distance++)
        {   
            Vector3 position = (direction * distance) + transform.position;
            ChessPieceBase chessPiece = _board.CheckIfPositionOccupied(position);

            if ((chessPiece != null && chessPiece.isActiveAndEnabled) || _board.CheckIfPositionOutOfBoard(position)) //czy stoi jakas figura lub koniec planszy 
            {
                if (chessPiece?.Color != _color && !canNotCapture) // jesli przeciwnik
                {
                    possibleMoves.Add(position); // dodaj bicia
                } 
                break;         
            }
            if (!isPawnMove) possibleMoves.Add(position); //dodaj nieblokowane ruchy         
        }

        return possibleMoves;
    }

    protected virtual void DisableOnCapture(ChessPieceBase chessPiece)
    {
        if(chessPiece == this)
        {
            gameObject.SetActive(false);
        }
    }
}
