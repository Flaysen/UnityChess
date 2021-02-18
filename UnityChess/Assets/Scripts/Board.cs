using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    const int SIZE_X = 8;
    const int SIZE_Z = 8; 

    [SerializeField]
    private Square _squarePrefab;

    private List<BoardPosition> _boardPositions = new List<BoardPosition>();
    private List<Square> _planes = new List<Square>();

    private MoveHandler _moveHandler;

    private void Awake()
    {
        InitializeBoardPositions();

        _moveHandler = FindObjectOfType<MoveHandler>();
        _moveHandler.OnChessPieceSelection += ColorPossibleMoves;
        _moveHandler.OnDeselection += ClearBoardColors;
        
    }
    private void CreatePlane(Vector3 position)
    {
        Square plane = Instantiate(_squarePrefab);
        plane.transform.parent = transform;

        plane.transform.localScale = new Vector3(.1f, 1f, .1f); 
        plane.transform.position = position;  

        plane.GetComponent<MeshRenderer>().material.color = ((position.x + position.z) % 2 == 0) ? Color.black : Color.white;

        _planes.Add(plane);
    }

    private void InitializeBoardPositions()
    {
        for (int x = 0; x < SIZE_X; x++)
        {
            for(int z = 0; z < SIZE_Z; z++)
            {            
                _boardPositions.Add(new BoardPosition(new Vector3(x, 0, z)));  
                CreatePlane(new Vector3(x, 0f, z));

            }
        }
    }

    private void ColorPossibleMoves(ChessPiece chessPiece)
    {   
        ClearBoardColors();

        foreach(Vector3 position in chessPiece.GetMoves())
        {
            Square plane = _planes.Where(x => x.transform.position == position).FirstOrDefault();
            if (plane != null) plane.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void ClearBoardColors()
    {
        foreach(Square plane in _planes)
        {
            Vector3 position = plane.transform.position; 
            plane.GetComponent<MeshRenderer>().material.color = ((position.x + position.z) % 2 == 0) ? Color.black : Color.white;
        }

    }
}
