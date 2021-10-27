using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractStateMachine : MonoBehaviour
{
    IState _currentState;
    protected IState _previousState;
    
    public IState _CurrentState => _currentState;

    protected List<IState> _stateList = new List<IState>();
    protected bool _InTransition { get; private set; }

    void Awake()
    {
        AddStates();
    }

    public void AddStates()
    {
        IState[] states = GetComponents<IState>();
        for(int i = 0; i <states.Length; i++)
        {
            _stateList.Add(states[i]);
        }

        print(_stateList.Count);
    }

    public void ChangeState<T>() where T: IState
    {
        T targetState = GetComponent<T>();

        if (targetState == null)
        {
            print("Current State Null");
            return;
        }

        InitiateCurrentState(targetState);
            
    }

    void InitiateCurrentState(IState newState)
    {
        if (_currentState != newState && !_InTransition)
            Transition(newState);
    }

    public void RevertState()
    {
        if (_previousState != null)
            InitiateCurrentState(_previousState);
    }

    void Transition(IState nextState)
    {
        _InTransition = true;

        _currentState?.Exit();
        _currentState = nextState;
        _currentState.Enter();

        _InTransition = false;
    }

    private void Update()
    {
        if (_currentState != null && !_InTransition)
            _currentState?.Tick();
    }
}