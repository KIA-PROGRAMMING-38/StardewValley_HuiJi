using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private PlayerInput _playerInput;

    [SerializeField]
    private Animator _animator;

    private Vector2 _cursorDirection;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _cursorDirection = _playerInput.GetMouseLoCalPosition();
            
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

        if (!Input.GetMouseButton(0))
        {
            _animator.SetTrigger("Idle");
        }
    }
}
