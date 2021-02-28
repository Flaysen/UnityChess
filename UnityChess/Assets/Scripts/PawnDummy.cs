using UnityEngine;

public class PawnDummy : ChessPieceBase
{
    private Pawn _pawn;
    private MoveHandler _moveHanlder;

    private void Awake()
    {
        _moveHanlder = FindObjectOfType<MoveHandler>();
        _moveHanlder.OnMove += (chessPiece) => { gameObject.SetActive(false); }; 
        _moveHanlder.OnCapture += DisableOnCapture;  
    }

    public void SetConnectedPawn(Pawn pawn)
    {
        _pawn = pawn;
        _color = pawn.Color;
    }

    protected override void DisableOnCapture(ChessPieceBase chessPiece, ChessPieceBase chessPiece1)
    {
        if(chessPiece == this && chessPiece1.Type == PiecesType.Pawn)
        {
            _pawn.gameObject.SetActive(false);
        }
    }
}
