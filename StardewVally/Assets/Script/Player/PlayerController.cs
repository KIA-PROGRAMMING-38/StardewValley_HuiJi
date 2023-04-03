using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum Direction
{
    Down,
    Left,
    Right,
    Up
}
public class PlayerController : MonoBehaviour
{
    public Direction CurrentDirection { get; private set; }
    
     
    private Animator[] _animator;
    private PlayerInput _playerInput; 
    
    [Range(0,10)] public float speed;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _animator = GetComponentsInChildren<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        CurrentDirection = Direction.Down;
    }

    void Update()
    {
        CurrentDirectionUpdate();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_playerInput.InputX, _playerInput.InputY) * speed;
    }

    private void CurrentDirectionUpdate()
    {
        if (_playerInput.InputY < 0)
        {
            CurrentDirection = Direction.Down;
            Debug.Log(_playerInput.InputY);
        }
        
        else if (_playerInput.InputY > 0)
        {
            CurrentDirection = Direction.Up;
        }
        
        else if (_playerInput.InputX < 0)
        {
            CurrentDirection = Direction.Left;
        }
        
        else if (_playerInput.InputX > 0)
        {
            CurrentDirection = Direction.Right;
        }
    }
}