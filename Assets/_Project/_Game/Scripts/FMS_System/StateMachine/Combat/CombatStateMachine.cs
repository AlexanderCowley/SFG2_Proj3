using UnityEngine;

public class CombatStateMachine : AbstractStateMachine
{
    [SerializeField] InputController _input;
    public InputController Input => _input;
    void Start() => ChangeState<TurnState>();
}