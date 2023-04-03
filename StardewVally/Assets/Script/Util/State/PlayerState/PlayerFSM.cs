using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : FiniteStateMachine
{
    
    public enum PlayerState
    {
        Idle,
        Run,
        Pick,
        UsePickaxe,
        UseWateringCan,
        Attack
    }

    public PlayerFSM(GameObject gameObject) : base(gameObject)
    {
        _states.Add(new PlayerIdleState());
        _states.Add(new PlayerRunState());

        CurrentState = _states[0];
    }
}
