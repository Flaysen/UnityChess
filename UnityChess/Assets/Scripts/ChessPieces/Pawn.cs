using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPieceBase
{
    public override List<Vector3> GetMoves()
    {
        Vector3 direction = (_color == PiecesColor.White) ?
            new Vector3(0, 0, 1) : new Vector3(0, 0, -1); 

        return (Moved) ? GetMovesInDirection(direction, 1f) :
            GetMovesInDirection(direction, 2f);
    }
}
