using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class QueueTurnOrder : CombatState
{
    [SerializeField] Text _stateText;
    bool _activated = false;

    CharacterController _target;

    List<CharacterController> _characters = 
        new List<CharacterController>(); 

    public override void Enter()
    {
        _stateText.text = "Queue Turn Order State";
        _stateText.gameObject.SetActive(true);

        _activated = false;

        _combatStateMachine.Input.PressedConfirmed += InputAction;
    }

    void InputAction()
    {
        _stateMachine.ChangeState<TurnState>();
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
        _combatStateMachine._characterTarget = _target;
        //_stateMachine.ChangeState<TurnState>();
    }
}