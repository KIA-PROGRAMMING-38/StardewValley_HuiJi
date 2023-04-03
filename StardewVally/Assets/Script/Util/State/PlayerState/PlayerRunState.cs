using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : State
{
    private Rigidbody2D _rigidbody;
    public float InputX { get; private set; }
    public float InputY { get; private set; }
    public override void OnEnter( FiniteStateMachine machine )
    {
        _rigidbody = machine.GameObject.GetComponent<Rigidbody2D>();
        machine.animator.SetBool("isMove", true);
    }
    
    
    public override void OnUpdate(FiniteStateMachine machine)
    {
        InputX = Input.GetAxisRaw("Horizontal");
        InputY = Input.GetAxisRaw("Vertical");
        _rigidbody.velocity = new Vector2(InputX,InputY) * machine.speed;

        // 우선 순위가 여기서 결정됨.
        if (InputX > 0)
        {
            machine.CurrentDirection = FiniteStateMachine.Direction.Right;
            machine.animator.SetFloat("Vertical", InputY);
        }
        
        else if (InputX < 0)
        {
            machine.CurrentDirection = FiniteStateMachine.Direction.Left;
            machine.animator.SetFloat("Vertical", InputY);
        }
        
        else if (InputY > 0)
        {
            machine.CurrentDirection = FiniteStateMachine.Direction.Up;
            machine.animator.SetFloat("Horizontal", InputX);
        }
        
        else if (InputY < 0)
        {
            machine.CurrentDirection = FiniteStateMachine.Direction.Down;
            machine.animator.SetFloat("Horizontal", InputX);
        }
        
        else if (InputX == 0 && InputY == 0)
        {
            machine.SetNextState((int)PlayerFSM.PlayerState.Idle);
            machine.animator.SetBool("isMove", false);
        }
    }
    
    
}


