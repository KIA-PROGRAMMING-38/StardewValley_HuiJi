using UnityEngine;

public abstract class State
{
    public virtual void OnCollisionEnter2D( FiniteStateMachine machine, Collision2D collision )
    {
    }

    public virtual void OnCollisionExit2D( FiniteStateMachine machine, Collision2D collision )
    {
    }

    public virtual void OnCollisionStay2D( FiniteStateMachine machine, Collision2D collision )
    {
    }

    public virtual void OnEnter( FiniteStateMachine machine )
    {
    }

    public virtual void OnExit( FiniteStateMachine machine )
    {
    }

    public virtual void OnUpdate( FiniteStateMachine machine )
    {
    }
}