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
    }

    protected override void DisableOnCapture(ChessPieceBase chessPiece)
    {
        if(chessPiece == this)
        {
             _pawn.gameObject.SetActive(false);
        }
    }
}
