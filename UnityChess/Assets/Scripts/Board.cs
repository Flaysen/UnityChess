using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public const int BOARD_SIZE = 8;
    [SerializeField] private Square _squarePrefab;
    public List<ChessPieceBase> ChessPieces = new List<ChessPieceBase>();
    private List<Square> _planes = new List<Square>();
    private MoveHandler _moveHandler;

    private void Awake()
    {
        SpawnBoard();

        _moveHandler = FindObjectOfType<MoveHandler>();
        _moveHandler.OnChessPieceSelection += ColorPossibleMoves;
        _moveHandler.OnDeselection += DrawChecker;       
    }

    public ChessPieceBase CheckIfPositionOccupied(Vector3 position)
    {
        ChessPieceBase chessPiece = ChessPieces.Where(p => p.transform.position == position).FirstOrDefault();
        return chessPiece;
    }

    public bool CheckIfPositionOutOfBoard(Vector3 position)
    {
        return (position.z >= BOARD_SIZE || position.x >= BOARD_SIZE || position.x < 0 || position.z < 0);
    }

    private void SpawnBoard()
    {
        for (int x = 0; x < BOARD_SIZE; x++)
        {
            for(int z = 0; z < BOARD_SIZE; z++)
            {              
                SpawnSquare(new Vector3(x, 0f, z));
            }
        }
        DrawChecker();
    }

    private void SpawnSquare(Vector3 position)
    {
        Square plane = Instantiate(_squarePrefab);
        plane.transform.parent = transform;

        plane.transform.localScale = new Vector3(.1f, 1f, .1f); //TODO set scale in prefab
        plane.transform.position = position;  

        _planes.Add(plane);
    }

    private void ColorPossibleMoves(ChessPieceBase chessPiece)
    {   
        DrawChecker();

        foreach(Vector3 position in chessPiece.GetMoves())
        {
            Square plane = _planes.Where(x => x.transform.position == position).FirstOrDefault();
            if (plane != null) plane.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void DrawChecker()
    {
        foreach(Square plane in _planes)
        {
            Vector3 position = plane.transform.position; 
            plane.GetComponent<MeshRenderer>().material.color = ((position.x + position.z) % 2 == 0) ? Color.black : Color.white;
        }
    }
}
