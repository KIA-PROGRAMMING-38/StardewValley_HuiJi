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
    private Vector3 mousePosition;
    // 메인 카메라
    public Camera mainCamera;
    // 방향
    private Vector3 dir;

    [SerializeField]
    private Animator _animator;

    [Range(0,10)] public float speed;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Left
            if (MathF.Abs(mousePosition.x) > MathF.Abs(mousePosition.y))
            {
                if (mousePosition.x < 0)
                {
                    _animator.SetFloat("MouseHorizontal", mousePosition.x);
                    _animator.SetFloat("MouseVertical", 0);
                }
            }

            // Right
            if (MathF.Abs(mousePosition.x) > MathF.Abs(mousePosition.y))
            {
                if (mousePosition.x > 0)
                {
                    _animator.SetFloat("MouseHorizontal", mousePosition.x);
                    _animator.SetFloat("MouseVertical", 0);
                }
            }
            
            // Down
            if (MathF.Abs(mousePosition.x) < MathF.Abs(mousePosition.y))
            {
                if (mousePosition.y < 0)
                {
                    _animator.SetFloat("MouseVertical", mousePosition.y);
                    _animator.SetFloat("MouseHorizontal", 0);
                }
            }
           
            
            // Up
            if (MathF.Abs(mousePosition.x) < MathF.Abs(mousePosition.y))
            {
                if (mousePosition.y > 0)
                {
                    _animator.SetFloat("MouseVertical", mousePosition.y);
                    _animator.SetFloat("MouseHorizontal", 0);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetTrigger("Idle");
            _animator.SetFloat("MouseVertical", 0);
            _animator.SetFloat("MouseHorizontal", 0);
            
        }
    }
}