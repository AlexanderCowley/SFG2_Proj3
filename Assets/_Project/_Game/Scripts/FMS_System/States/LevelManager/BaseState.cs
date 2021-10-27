using UnityEngine;

public class BaseState : MonoBehaviour, IState
{
    protected AbstractStateMachine _stateMachine { get; private set; }
    void Awake() => _stateMachine = GetComponent<AbstractStateMachine>();

    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
        
    }

    public virtual void FixedTick()
    {
        
    }

    public virtual void Tick()
    {
        
    }
}