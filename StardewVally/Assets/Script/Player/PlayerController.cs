using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    // 메인 카메라
    private Camera _mainCamera;
    
    // 초기 마우스 포지션
    private Vector3 mousePosition;
    // 마우스 월드 포지션
    private Vector2 _mouseWorldPosition;
    
    // 마우스의 방향
    private Vector2 _cursorDirection;

    [SerializeField]
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _mainCamera = Camera.main;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int cellPosition = MapManager.Instance.GetCellPositionFromWorld(transform.position);
            Debug.Log($"�÷��̾��� ���� ��ġ�� �� ��ǥ�� : {cellPosition}");
        }
        
        if (Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;
            _mouseWorldPosition = _mainCamera.ScreenToWorldPoint(mousePosition);

            _cursorDirection = _mouseWorldPosition - (Vector2)transform.position;

            float absXValue = Mathf.Abs(_cursorDirection.x);
            float absYValue = Mathf.Abs(_cursorDirection.y);

            // Right
            // 1,4사분면
            if (_cursorDirection.y > 0)
            {
                // 1사분면
                if (_cursorDirection.x >= 0)
                {
                    // Right
                    if (absXValue >= absYValue)
                    {
                        _animator.Play("Hoe_Right");
                    }

                    // Up
                    else
                    {
                        _animator.Play("Hoe_Up");
                    }
                }

                // 4사분면
                else
                {
                    // Left
                    if (absXValue >= absYValue)
                    {
                        _animator.Play("Hoe_Left");
                    }

                    // Up
                    else
                    {
                        _animator.Play("Hoe_Up");
                    }
                }
            }

            // 2, 3사분면
            else
            {
                // 2사분면
                if (_cursorDirection.x >= 0)
                {
                    // Right
                    if (absXValue >= absYValue)
                    {
                        _animator.Play("Hoe_Right");
                    }

                    // Down
                    else
                    {
                        _animator.Play("Hoe_Down");
                    }
                }

                // 3사분면
                else
                {
                    // Left
                    if (absXValue >= absYValue)
                    {
                        _animator.Play("Hoe_Left");
                    }

                    // Down
                    else
                    {
                        _animator.Play("Hoe_Down");
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetTrigger("Idle");
        }
    }
}