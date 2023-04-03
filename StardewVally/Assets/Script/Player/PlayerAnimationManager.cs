using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class PlayerAnimID
{
    public static readonly int RUN_DOWN = Animator.StringToHash("Run_Down");
    public static readonly int RUN_LEFT = Animator.StringToHash("Run_Left");
    public static readonly int RUN_RIGHT = Animator.StringToHash("Run_Right");
    public static readonly int RUN_UP = Animator.StringToHash("Run_Up");
}

public class PlayerAnimationManager : MonoBehaviour
{
    private PlayerController _playerController;
    private Animator _animator;
    
    private void Awake()
    {
        _playerController = GetComponentInParent<PlayerController>();
        _animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (_playerController.IsMove)
        {
            switch (_playerController.CurrentDirection)
            {
                case Direction.Down:
                    _animator.Play(PlayerAnimID.RUN_DOWN);
                    break;
            
                case Direction.Up:
                    _animator.Play(PlayerAnimID.RUN_UP);
                    break;
            
                case Direction.Left:
                    _animator.Play(PlayerAnimID.RUN_LEFT);
                    break;
            
                case Direction.Right:
                    _animator.Play(PlayerAnimID.RUN_RIGHT);
                    break;
            }

            if (!_playerController.IsMove)
            {
                _animator.SetBool("isMove", false);
            }
        }
        
    }
}
