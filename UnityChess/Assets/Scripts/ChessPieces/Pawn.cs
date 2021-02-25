using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPieceBase
{
    [SerializeField] private Queen _queenPrefab;
    private int promotionRank;
    private MoveHandler _moveHandler;

    private void Awake()
    {
        promotionRank = (_color ==  PiecesColor.White) ? 7 : 0;   

        _moveHandler = FindObjectOfType<MoveHandler>();
        _moveHandler.OnMove += LookForPromotion;    
    }

    public override List<Vector3> GetMoves()
    {
        List<Vector3> possibleMoves = new List<Vector3>();

        Vector3 direction = (_color == PiecesColor.White) ?
            new Vector3(0, 0, 1) : new Vector3(0, 0, -1); 

        possibleMoves = (Moved) ? GetMovesInDirection(direction, 1f, false, true) :
            GetMovesInDirection(direction, 2f, false, true);

        possibleMoves.AddRange(GetMovesInDirection(new Vector3(1, 0, 1), 1f, true));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(-1, 0, 1), 1f, true));
 
        return possibleMoves;
    }

    public void LookForPromotion(ChessPieceBase chessPiece)
    {
        if(chessPiece.transform.position.z == promotionRank && chessPiece == this)
        {
            chessPiece.gameObject.SetActive(false);
            Queen queen = Instantiate(_queenPrefab, transform.position, Quaternion.identity);
            queen.SetColor(_color);
            RegisterPieceOnBoard(queen);         
        }
    }
}

