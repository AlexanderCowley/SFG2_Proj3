using UnityEngine.UI;
using UnityEngine;

public class TurnState : CombatState
{
    [SerializeField] Text _stateText;
    int _turnCount = 0;

    public override void Enter()
    {
        _stateText.text = "Turn Start";
        _stateText.gameObject.SetActive(true);

        _turnCount++;

        _stateText.text = "Turn Number: " + _turnCount.ToString();

        _combatStateMachine.Input.PressedConfirmed += InputAction;
    }

    void InputAction()
    {
        _stateMachine.ChangeState<EnemyTurnState>();
    }

    public override void Exit()
    {
        _stateText.gameObject.SetActive(false);

        _combatStateMachine.Input.PressedConfirmed -= InputAction;
    }

    public override void Tick()
    {
        
    }
}