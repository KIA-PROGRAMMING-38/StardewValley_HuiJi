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
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");
        // 플레이어를 움직인다.
        _rigidbody.velocity = new Vector2(InputX,InputY) * machine.speed;

        // 움직이고 있지 않을때 Idle상태로 전이한다.
        // RunState중 어느 transition으로도 갈 수 없게 Vertical과 Horizontal의 값을 각각 0으로 준다.
        if (InputX == 0 && InputY == 0)
        {
            machine.animator.SetFloat("Vertical", 0);
            machine.animator.SetFloat("Horizontal", 0);
            machine.SetNextState((int)PlayerFSM.PlayerState.Idle);
            machine.animator.SetBool("isMove", false);
        }

        // 한방향으로만 움직일때
        if (InputX * InputY == 0)
        {
            machine.animator.SetFloat("Vertical", InputY);
            machine.animator.SetFloat("Horizontal", InputX);
        }
        
        // 대각선으로 움직일대 Horizontal transition을 가지고 있는 애니메이션만 실행한다.
        // 좌, 우 애니메이션의 우선순위가 더 높다.
        else
        {
            machine.animator.SetFloat("Horizontal", InputX);
            machine.animator.SetFloat("Vertical", 0);
        }
    }
}


