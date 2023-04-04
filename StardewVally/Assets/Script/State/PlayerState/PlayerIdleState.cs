using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerIdleState : State
{
    public override void OnEnter(FiniteStateMachine machine)
    {
        machine.animator.Play("Idle_Down");
    }
    public override void OnUpdate(FiniteStateMachine machine)
    {
        // Run으로 전환
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            machine.SetNextState((int)PlayerFSM.PlayerState.Run);
        }
        
        // UsePickaxe로 전환
        if (Input.GetMouseButton(0))
        {
            machine.SetNextState((int)PlayerFSM.PlayerState.UsePickaxe);
            Debug.Log("마우스를 누름");
        }
    }
}
