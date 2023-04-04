using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePickaxeState : State
{
    private float _elapsedTime;
    private bool animationOver;
    public override void OnEnter( FiniteStateMachine machine )
    {
        machine.animator.Play("Pickaxe_Down");
        _elapsedTime = 0;
        animationOver = false;
    }

    public override void OnUpdate( FiniteStateMachine machine )
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= 1f)
        {
            _elapsedTime = 0;
            animationOver = true;
            
            // 여러키가 동시에 입력될때 마우스 버튼이 때지는 순간을 Update가 놓칠 수도 있다.
            // 그래서 GetMouseButtonUp을 사용하지 않고 좌클릭을 하지 않는 순간을 if문으로 주는것. 
            if (!Input.GetMouseButton(0))
            {
                machine.SetNextState((int)PlayerFSM.PlayerState.Idle);
            }
        }
    }
}
