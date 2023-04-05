using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunStateBehaviour : StateMachineBehaviour
{
    private Rigidbody2D _rigid;
    public float InputX { get; private set; }
    public float InputY { get; private set; }
    private float _speed = 5f;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rigid = animator.GetComponentInParent<Rigidbody2D>();
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");
        // 플레이어를 움직인다.
        _rigid.velocity = new Vector2(InputX,InputY) * _speed;

        // 움직이고 있지 않을때 Idle상태로 전이한다.
        // RunState중 어느 transition으로도 갈 수 없게 Vertical과 Horizontal의 값을 각각 0으로 준다.
        if (InputX == 0 && InputY == 0)
        {
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Horizontal", 0);
            animator.SetBool("isMove", false);
        }

        // 한방향으로만 움직일때
        if (InputX * InputY == 0)
        {
            animator.SetFloat("Vertical", InputY);
            animator.SetFloat("Horizontal", InputX);
        }
        
        // 대각선으로 움직일대 Horizontal transition을 가지고 있는 애니메이션만 실행한다.
        // 좌, 우 애니메이션의 우선순위가 더 높다.
        else
        {
            animator.SetFloat("Horizontal", InputX);
            animator.SetFloat("Vertical", 0);
        }
    }
}
