using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Rook : ChessPiece
{
    public override List<Vector3> GetMoves()
    {
        List<Vector3> possibleMoves = new List<Vector3>();

        // for(int x = 0 - (int)transform.position.x; x + transform.position.x < 8; x++)
        // {       
        //     Vector3 position = new Vector3(x, 0, 0) + transform.position;  
        //     if(position != transform.position && position.x < 8 && position.z < 8 && position.x >= 0 && position.z >= 0)
        //     {
        //         possibleMoves.Add(position);   
        //     }
        // }
        // for(int z = 0 - (int)transform.position.z; z + transform.position.z < 8; z++)
        // {
        //     Vector3 position = new Vector3(0, 0, z) + transform.position;  
        //     if(position != transform.position && position.x < 8 && position.z < 8 && position.x >= 0 && position.z >= 0)
        //     {
        //         possibleMoves.Add(position);   
        //     }
        // }

        // foreach(Vector3 x in possibleMoves)
        // {
        //     Debug.Log(x);
        // }

        //  Debug.Log(possibleMoves.Count);
        for(int i = 1; i < 8; i++)
        {
            Vector3 position = new Vector3(0, 0, i) + transform.position;
            if(Board.ChessPieces.Where(p => p.transform.position == position).FirstOrDefault() != null || position.z >= 8)
            {
               break;
            }
            possibleMoves.Add(position);         
        }
        for(int i = 1; i < 8; i++)
        {
            Vector3 position = new Vector3(i, 0, 0) + transform.position;
            if(Board.ChessPieces.Where(p => p.transform.position == position).FirstOrDefault() != null || position.x >= 8)
            {
               break;
            }
            possibleMoves.Add(position);         
        }
        for(int i = 1; i < 8; i++)
        {
            Vector3 position = new Vector3(0, 0, -i) + transform.position;
            if(Board.ChessPieces.Where(p => p.transform.position == position).FirstOrDefault() != null || position.z < 0)
            {
               break;
            }
            possibleMoves.Add(position);         
        }
        for(int i = 1; i < 8; i++)
        {
            Vector3 position = new Vector3(-i, 0, 0) + transform.position;
            if(Board.ChessPieces.Where(p => p.transform.position == position).FirstOrDefault() != null || position.x < 0)
            {
               break;
            }
            possibleMoves.Add(position);         
        }




        return possibleMoves;
    }
}
