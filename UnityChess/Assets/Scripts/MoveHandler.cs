using System;
using UnityEngine;

public class MoveHandler : MonoBehaviour // TO REFACTOR
{
    private Camera _camera;
    private ChessPieceBase _selectedChessPiece;
    public event Action<ChessPieceBase> OnChessPieceSelection;
    public event Action<ChessPieceBase> OnMove;
    public event Action<ChessPieceBase, ChessPieceBase> OnCapture;
    public event Action OnDeselection;
  
    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();    
    }
        
    void Update()
    {
        if(_selectedChessPiece == null) 
        {
            ChessPieceBase chessPiece = GetRaycastedChessPiece();

            if(chessPiece != null)
            {               
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _selectedChessPiece = chessPiece;
                    OnChessPieceSelection?.Invoke(chessPiece);
                }
            }
        }
        else
        {
            Square square = GetRaycastedSquare();

            if(square != null)
            {               
                if(Input.GetKeyDown(KeyCode.Mouse0) && _selectedChessPiece.GetMoves().Contains(square.transform.position))
                {
                    _selectedChessPiece.transform.position = square.transform.position;
                    OnMove?.Invoke(_selectedChessPiece);
                    OnDeselection?.Invoke();
                    _selectedChessPiece = null; 
                }
            }

            ChessPieceBase chessPiece = GetRaycastedChessPiece();

            if(chessPiece != null)
            {               
                if(Input.GetKeyDown(KeyCode.Mouse0) && _selectedChessPiece != null && _selectedChessPiece.GetMoves().Contains(chessPiece.transform.position))
                {
                    _selectedChessPiece.transform.position = chessPiece.transform.position;
                    OnMove?.Invoke(_selectedChessPiece);
                    OnCapture?.Invoke(chessPiece, _selectedChessPiece);          
                    OnDeselection?.Invoke();
                    _selectedChessPiece = null; 
                }
            }

        }    
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            OnDeselection?.Invoke();
            _selectedChessPiece = null;
        }              
    }
    private ChessPieceBase GetRaycastedChessPiece()
    {
        RaycastHit hitInfo;       
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hitInfo))
        {
            ChessPieceBase chessPiece = hitInfo.collider.GetComponent<ChessPieceBase>();
            return (chessPiece) ? chessPiece : null;
        }
        else return null;
    }

    private Square GetRaycastedSquare()
    {
        RaycastHit hitInfo;       
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hitInfo))
        {
            Square square = hitInfo.collider.GetComponent<Square>();
            return (square) ? square : null;
        }
        else return null;
    }
}
