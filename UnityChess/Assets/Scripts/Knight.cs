using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    public override List<Vector3> GetMoves()
    {
         List<Vector3> possibleMoves = new List<Vector3>();

        possibleMoves.Add(new Vector3(2, 0, 1) + transform.position);
        possibleMoves.Add(new  Vector3(2, 0, -1) + transform.position);
        possibleMoves.Add(new Vector3(-2, 0, 1) + transform.position);
        possibleMoves.Add(new  Vector3(-2, 0, -1) + transform.position);
        possibleMoves.Add(new Vector3(1, 0, 2) + transform.position);
        possibleMoves.Add(new  Vector3(-1, 0, 2) + transform.position);
        possibleMoves.Add(new Vector3(1, 0, -2) + transform.position);
        possibleMoves.Add(new  Vector3(-1, 0, -2) + transform.position);

        return possibleMoves;
    }
}
