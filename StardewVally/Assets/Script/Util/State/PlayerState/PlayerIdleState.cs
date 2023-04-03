using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : State
{
    public override void OnUpdate(FiniteStateMachine machine)
    {
        // Run으로 전환
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            machine.SetNextState((int)PlayerFSM.PlayerState.Run);
        }
    }
}
