using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    public override List<Vector3> GetMoves()
    {
         List<Vector3> possibleMoves = new List<Vector3>();

        possibleMoves.Add(new Vector3(1, 0, 0) + transform.position);
        possibleMoves.Add(new  Vector3(0, 0, 1) + transform.position);
        possibleMoves.Add(new Vector3(-1, 0, 0) + transform.position);
        possibleMoves.Add(new  Vector3(0, 0, -1) + transform.position);
        possibleMoves.Add(new Vector3(1, 0, 1) + transform.position);
        possibleMoves.Add(new  Vector3(-1, 0, -1) + transform.position);
        possibleMoves.Add(new Vector3(1, 0, -1) + transform.position);
        possibleMoves.Add(new  Vector3(-1, 0, 1) + transform.position);

        return possibleMoves;
    }
}
