using System.Collections.Generic;
using UnityEngine;

public abstract class FiniteStateMachine // 뇌
{
    // 나중에 마우스 위치..? 저장하기 위해서 사용할수도 있음.
    public enum Direction
    {
        Down,
        Up,
        Left,
        Right
    }

    public Direction CurrentDirection;
    
    // 다른 객체들도 Speed를 가지니 FSM에서 speed를 가지고 있게 한다.
    // 왜냐하면 PlayerRunState에서 speed가 필요하기 때문에
    // 그리고 State Script는 오브젝트에 부착시키지 않기 때문에 인스펙터창에서 speed를 설정해줄 수 없다.
    // 그렇기 때문에 오브젝트에 부착되어있는 Controller Script에서 Speed를 설정할 수 있게 한다.
    // speed의 set을 어디서 하고 있는지 Cmd + D로 확인해보자.
    public float speed { get; set; }
    
    /* 가독성을 위해 Controller에서 애니메이션을 실행시키지 않고
     State에서 animator를 실행시키기 위해 FSM에다 animator를 만들어둔다.*/
    public Animator animator { get; set; }
    
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