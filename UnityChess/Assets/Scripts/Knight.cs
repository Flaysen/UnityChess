using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    public override List<Vector3> GetMoves()
    {
         List<Vector3> possibleMoves = new List<Vector3>();

        possibleMoves.AddRange(GetMovesInDirection(new Vector3(2, 0, 1), 1f));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(2, 0, -1), 1f));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(-2, 0, 1), 1f));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(-2, 0, -1), 1f));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(1, 0, 2), 1f));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(-1, 0, 2), 1f));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(1, 0, -2), 1f));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(-1, 0, -2), 1f));

        return possibleMoves;
    }
}
