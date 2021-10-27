using UnityEngine.UI;
using UnityEngine;

public class QueueTurnOrder : CombatState
{
    [SerializeField] Text _stateText;
    bool _activated = false;

    public override void Enter()
    {
        _stateText.text = "Queue Turn Order";
        _stateText.gameObject.SetActive(true);

        _activated = false;
    }

    //Find Next Character Turn

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
        _stateMachine.ChangeState<TurnState>();
    }
}