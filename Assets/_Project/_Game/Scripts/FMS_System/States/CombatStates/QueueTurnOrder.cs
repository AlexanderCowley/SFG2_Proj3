using UnityEngine.UI;
using UnityEngine;

public class QueueTurnOrder : CombatState
{
    [SerializeField] Text _stateText;
    bool _activated = false;

    CharacterController _target;

    public override void Enter()
    {
        _stateText.text = "Queue Turn Order";
        _stateText.gameObject.SetActive(true);

        _activated = false;
    }

    //Find Next Character Turn
    //If no enemies are present Achieve Win State
    //If no players are present Achieve Lose State

    public override void Exit()
    {
        _stateText.gameObject.SetActive(false);

        _activated = false;
    }

    public override void Tick()
    {
        if (_activated)
            return;
        _activated = true;
        print("Change State to Turn");
        _combatStateMachine._characterTarget = _target;
        _stateMachine.ChangeState<TurnState>();
    }
}