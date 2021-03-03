using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public const int BOARD_SIZE = 8;
    [SerializeField] private Square _squarePrefab;
    public List<ChessPieceBase> ChessPieces = new List<ChessPieceBase>();
    private List<Square> _squares = new List<Square>();
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

    public bool CheckIfCheck(PiecesColor color)
    {
        foreach (ChessPieceBase chessPiece in ChessPieces)
        {
            List<Vector3> moves = chessPiece?.GetMoves();
            if(moves?.Count > 0)
            {
                foreach (Vector3 position in moves)
                {
                    ChessPieceBase piece = CheckIfPositionOccupied(position);
                    if (piece?.Type == PiecesType.King && chessPiece.isActiveAndEnabled && piece?.Color == color)
                    {
                        Debug.Log("CHECK!!!");
                        return true;
                    }         
                }
            }
           
        }
        return false;
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
        Square square = Instantiate(_squarePrefab);
        square.SetName((int)position.x, (int)position.z);

        square.transform.parent = transform;

        square.transform.localScale = new Vector3(.1f, 1f, .1f); //TODO: set scale in prefab
        square.transform.position = position;  


        _squares.Add(square);
    }

    private void ColorPossibleMoves(ChessPieceBase chessPiece)
    {   
        DrawChecker();

        foreach(Vector3 position in chessPiece.GetMoves())
        {
            Square plane = _squares.Where(x => x.transform.position == position).FirstOrDefault();
            ChessPieceBase figureToCapture = (CheckIfPositionOccupied(position));
            if (plane != null) plane.GetComponent<MeshRenderer>().material.color = (figureToCapture?.Color != chessPiece?.Color && figureToCapture != null && figureToCapture.isActiveAndEnabled) ? Color.red : Color.cyan;
        }
    }

    private void DrawChecker()
    {
        foreach(Square plane in _squares)
        {
            Vector3 position = plane.transform.position; 
            plane.GetComponent<MeshRenderer>().material.color = ((position.x + position.z) % 2 == 0) ? Color.black : Color.white;
        }
    }
}
