using System.Collections.Generic;
using UnityEngine;

public abstract class FiniteStateMachine // 뇌
{
    public enum Direction
    {
        Down,
        Up,
        Left,
        Right
    }
    
    // 다른 클래스에서 speed를 설정할 수 없게 private로 설정.
    public float speed { get; set; }
    
    public Animator animator { get; set; }

    public Direction CurrentDirection { get; set; } 
    // 상태를 가지는 객체
    // 플레이어
    public GameObject GameObject { get; private set; }

    // 현재 상태
    public State CurrentState { get; set; }

    // 여러 상태를 담을 리스트 생성
    protected List<State> _states = new List<State>();

    // 생성자를 만들 때 반드시 게임오브젝트를 남겨주겠다고 규칙 생성
    // 여기에서 플레이어를 넘겨줌.
    public FiniteStateMachine(GameObject gameObject )
    {
        GameObject = gameObject;
    }

    // this가 가리키는건 생성자에서 넘겨준 게임 오브젝트.
    // CurrentState의 OnUpdate에 gameObject를 넘겨줌.
    public void Update()
    {
        CurrentState.OnUpdate(this);
    }

    // this 오브젝트랑, 충돌한 오브젝트를 넘겨줌.
    // gameObject랑 collision이 부딪혔다고 알려줌.
    public void OnCollisionEnter2D(Collision2D collision)
    {
        CurrentState.OnCollisionEnter2D( this, collision );
    }

    
    public void SetNextState( int index )
    {
        CurrentState.OnExit( this );

        CurrentState = _states[index];
        
        CurrentState.OnEnter( this );
    }
}