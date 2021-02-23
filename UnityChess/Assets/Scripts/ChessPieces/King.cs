using System.Collections.Generic;
using UnityEngine;

public class King : ChessPieceBase
{
    public override List<Vector3> GetMoves()
    {
        List<Vector3> possibleMoves = new List<Vector3>();

        possibleMoves.AddRange(GetMovesInDirection(new Vector3(0, 0, 1), 1f));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(1, 0, 0), 1f));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(0, 0, -1), 1f));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(-1, 0, 0), 1f));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(1, 0, 1), 1f));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(-1, 0, -1), 1f));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(-1, 0, 1), 1f));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(1, 0, -1), 1f));

        return possibleMoves;
    }
}
