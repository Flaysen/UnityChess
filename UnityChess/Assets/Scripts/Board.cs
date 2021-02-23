using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public const int BOARD_SIZE = 8;

    [SerializeField]
    private Square _squarePrefab;

    //private List<BoardPosition> _boardPositions = new List<BoardPosition>();

    public List<ChessPiece> ChessPieces = new List<ChessPiece>();
    public List<Square> Planes = new List<Square>();

    private MoveHandler _moveHandler;

    private void Awake()
    {
        InitializeBoardPositions();

        _moveHandler = FindObjectOfType<MoveHandler>();
        _moveHandler.OnChessPieceSelection += ColorPossibleMoves;
        _moveHandler.OnDeselection += ClearBoardColors;       
    }

    public bool CheckIfPositionOccupied(Vector3 position)
    {
        return ChessPieces.Where(p => p.transform.position == position).FirstOrDefault();
    }

    public bool CheckIfPositionOutOfBoard(Vector3 position)
    {
        return (position.z >= BOARD_SIZE || position.x >= BOARD_SIZE || position.x < 0 || position.z < 0);
    }

    private void CreatePlane(Vector3 position)
    {
        Square plane = Instantiate(_squarePrefab);
        plane.transform.parent = transform;

        plane.transform.localScale = new Vector3(.1f, 1f, .1f); 
        plane.transform.position = position;  

        plane.GetComponent<MeshRenderer>().material.color = ((position.x + position.z) % 2 == 0) ? Color.black : Color.white;

        Planes.Add(plane);
    }

    private void InitializeBoardPositions()
    {
        for (int x = 0; x < BOARD_SIZE; x++)
        {
            for(int z = 0; z < BOARD_SIZE; z++)
            {            
                //_boardPositions.Add(new BoardPosition(new Vector3(x, 0, z)));  
                CreatePlane(new Vector3(x, 0f, z));

            }
        }
    }

    private void ColorPossibleMoves(ChessPiece chessPiece)
    {   
        ClearBoardColors();

        foreach(Vector3 position in chessPiece.GetMoves())
        {
            Square plane = Planes.Where(x => x.transform.position == position).FirstOrDefault();
            if (plane != null) plane.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void ClearBoardColors()
    {
        foreach(Square plane in Planes)
        {
            Vector3 position = plane.transform.position; 
            plane.GetComponent<MeshRenderer>().material.color = ((position.x + position.z) % 2 == 0) ? Color.black : Color.white;
        }

    }
}
