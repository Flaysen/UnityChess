using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPieceBase
{
    public override List<Vector3> GetMoves()
    {
        return (Moved) ? GetMovesInDirection(new Vector3(0, 0, 1), 1f) :
            GetMovesInDirection(new Vector3(0, 0, 1), 2f);
    }
}
