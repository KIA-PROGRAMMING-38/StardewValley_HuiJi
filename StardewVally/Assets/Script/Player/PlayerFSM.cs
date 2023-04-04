using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : FiniteStateMachine
{
    
    public enum PlayerState
    {
        Idle,
        Run,
        UsePickaxe,
        Pick,
        UseWateringCan,
        Attack
    }

    public PlayerFSM(GameObject gameObject) : base(gameObject)
    {
        _states.Add(new PlayerIdleState());
        _states.Add(new PlayerRunState());
        _states.Add(new UsePickaxeState());

        CurrentState = _states[0];
    }
}
