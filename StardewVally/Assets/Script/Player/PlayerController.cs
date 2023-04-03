using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private PlayerFSM _fsm;
    public Direction CurrentDirection { get; private set; }

    [SerializeField] 
    private Animator _animator;
    
    private PlayerInput _playerInput; 
    
    [Range(0,10)] public float speed;
    private Rigidbody2D _rigidbody;

    public bool IsMove;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _fsm = new PlayerFSM(gameObject);
        _fsm.speed = this.speed;
        _fsm.animator = this._animator;
    }

    private void Start()
    {
        CurrentDirection = Direction.Down;
        IsMove = false;
    }

    void Update()
    {
        _fsm.Update();
        // CurrentDirectionUpdate();
        // isMoveUpdate();
    }

    private void FixedUpdate()
    {
        
    }

    private void CurrentDirectionUpdate()
    {
        if (_playerInput.InputY < 0)
        {
            CurrentDirection = Direction.Down;
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

    private void isMoveUpdate()
    {
        if (_playerInput.InputX == 0 && _playerInput.InputY == 0)
        {
            IsMove = false;
        }
        
        else
        {
            IsMove = true;
        }
    }
    
    
}