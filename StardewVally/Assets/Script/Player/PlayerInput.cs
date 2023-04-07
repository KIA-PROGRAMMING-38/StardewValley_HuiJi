using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // public string HorizontaolAxisName = "Horizontal";
    // public string VerticalAxisName = "Vertical";
    // public float InputX { get; private set; }
    // public float InputY { get; private set; }
    
    // 마우스 포지션 알아내야함.
    // 메인 카메라
    private Camera _mainCamera;
    
    // 초기 마우스 포지션
    private Vector3 mousePosition;
    // 마우스 월드 포지션
    private Vector2 _mouseWorldPosition;
    
    // 마우스의 방향
    private Vector2 _cursorDirection;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        // InputX = Input.GetAxisRaw(HorizontaolAxisName);
        // InputY = Input.GetAxisRaw(VerticalAxisName);
        
        // MapManager에서 GetCellPositionFromWorld 가져와야함.
        if (Input.GetMouseButtonDown(0))
        {
            Vector3Int cellPosition = MapManager.Instance.GetCellPositionFromWorld(transform.position);
            Debug.Log($"플레이어의 현재 위치한 셀 좌표는 : {cellPosition}");
        }
    }

    public Vector2 GetMouseLoCalPosition()
    {
        mousePosition = Input.mousePosition;
        _mouseWorldPosition = _mainCamera.ScreenToWorldPoint(mousePosition);

        _cursorDirection = _mouseWorldPosition - (Vector2)transform.position;

        return _cursorDirection;
    }
}
