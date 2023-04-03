using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FiniteStateMachine
{
    // 상태를 가지는 객체
    public GameObject GameObject { get; private set; }
    
    // 현재 상태
    public State CurrentState { get; set; }

    protected List<State> _states;

    void Update()
    {
        
    }
}
