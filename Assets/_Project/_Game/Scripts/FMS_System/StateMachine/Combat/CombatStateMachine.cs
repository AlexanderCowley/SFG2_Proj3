using UnityEngine;

public class CombatStateMachine : AbstractStateMachine
{
    [SerializeField] InputController _input;
    public InputController Input => _input;

    public CharacterController _characterTarget;
    void Start() => ChangeState<TurnState>();
}