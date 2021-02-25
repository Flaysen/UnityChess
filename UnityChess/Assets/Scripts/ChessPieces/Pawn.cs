using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPieceBase
{
    [SerializeField] private Queen _queenPrefab;
    [SerializeField] private PawnDummy _pawnDummy;
    private int promotionRank;
    private MoveHandler _moveHandler;

    private void Awake()
    {
        promotionRank = (_color ==  PiecesColor.White) ? 7 : 0;   

        _moveHandler = FindObjectOfType<MoveHandler>();
        _moveHandler.OnMove += LookForPromotion;  
        _moveHandler.OnMove += SetCaptureForInPassing;
        _moveHandler.OnMove += (chessPiece) => { if(chessPiece == this) Moved = true; };
    }

    public override List<Vector3> GetMoves()
    {
        List<Vector3> possibleMoves = new List<Vector3>();

        int side = (_color == PiecesColor.White) ? 1 : -1;

        Vector3 direction =  new Vector3(0, 0, side);

        possibleMoves = (Moved) ? GetMovesInDirection(direction, 1f, false, true) :
            GetMovesInDirection(direction, 2f, false, true);

        possibleMoves.AddRange(GetMovesInDirection(new Vector3(1, 0, side), 1f, true));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(-1, 0, side), 1f, true));
 
        return possibleMoves;
    }

    public void LookForPromotion(ChessPieceBase chessPiece)
    {
        if (chessPiece == this && chessPiece.transform.position.z == promotionRank)
        {
            Debug.Log("PROMO");
            chessPiece.gameObject.SetActive(false);
            Queen queen = Instantiate(_queenPrefab, transform.position, Quaternion.identity);
            queen.SetColor(_color);
            RegisterPieceOnBoard(queen);         
        }
    }

    public void SetCaptureForInPassing(ChessPieceBase chessPiece)
    {
         int rank = (_color == PiecesColor.White) ? 3 : 4;

         int side = (_color == PiecesColor.White) ? 1 : -1;

        if (chessPiece == this && !Moved && transform.position.z == rank)
        {
            Debug.Log("Spawn");
            PawnDummy pawnDummy = Instantiate(_pawnDummy, chessPiece.transform.position - new Vector3(0, 0, side), Quaternion.identity);
            pawnDummy.SetConnectedPawn(this);
        }
    }
}

