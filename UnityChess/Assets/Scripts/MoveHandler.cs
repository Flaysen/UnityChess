using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHandler : MonoBehaviour
{
        private Camera _camera;

        private ChessPiece _selectedChessPiece;
        public event Action<ChessPiece> OnChessPieceSelection;
        public event Action OnDeselection;
        
        private void Awake()
        {
            _camera = FindObjectOfType<Camera>();    
        }

        void Start()
        {
            
        }
            
        void Update()
        {
            if(_selectedChessPiece == null) 
            {
                ChessPiece chessPiece = GetRaycastedChessPiece();

                if(chessPiece != null)
                {               
                    if(Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        Debug.Log(chessPiece.Name);
                        _selectedChessPiece = chessPiece;
                        OnChessPieceSelection?.Invoke(chessPiece);
                    }
                }
            }
            else
            {
                Square square = GetRaycastedSquare();

                if(square != null )
                {               
                    if(Input.GetKeyDown(KeyCode.Mouse0) && _selectedChessPiece.GetMoves().Contains(square.transform.position))
                    {
                        _selectedChessPiece.transform.position = square.transform.position;
                        _selectedChessPiece.Moved = true;
                        _selectedChessPiece = null;
                        OnDeselection?.Invoke();
                    }
                }
            }    
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                OnDeselection?.Invoke();
                _selectedChessPiece = null;
            }              
        }
        private ChessPiece GetRaycastedChessPiece()
        {
            RaycastHit hitInfo;       
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hitInfo))
            {
                ChessPiece chessPiece = hitInfo.collider.GetComponent<ChessPiece>();
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
