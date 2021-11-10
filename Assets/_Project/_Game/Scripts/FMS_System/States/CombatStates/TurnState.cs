using UnityEngine.UI;
using UnityEngine;

public class TurnState : CombatState
{
    [SerializeField] Text _stateText;
    int _turnCount = 0;

    CharacterController _turnTargetController;

    public override void Enter()
    {
        GetTarget();
        _stateText.gameObject.SetActive(true);
        _turnCount++;

        _stateText.text = "Turn Number: " + _turnCount.ToString();

        _combatStateMachine.Input.PressedConfirmed += InputAction;

        //_turnTargetController.EnableInput();
    }

    public void GetTarget() => _turnTargetController = _combatStateMachine._characterTarget;

    void InputAction()
    {
        _stateMachine.ChangeState<QueueTurnOrder>();
    }

    public override void Exit()
    {
        _stateText.gameObject.SetActive(false);

        //_turnTargetController.DisableInput();
        _turnTargetController = null;
        _combatStateMachine.Input.PressedConfirmed -= InputAction;
    }

    public override void Tick()
    {
        
    }
}