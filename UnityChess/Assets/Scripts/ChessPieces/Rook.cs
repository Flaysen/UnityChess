using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPieceBase
{
    public override List<Vector3> GetMoves()
    {
        List<Vector3> possibleMoves = new List<Vector3>();
          
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(0, 0, 1), Mathf.Infinity));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(1, 0, 0), Mathf.Infinity));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(0, 0, -1), Mathf.Infinity));
        possibleMoves.AddRange(GetMovesInDirection(new Vector3(-1, 0, 0), Mathf.Infinity));
       
        return possibleMoves;
    }

    
}
