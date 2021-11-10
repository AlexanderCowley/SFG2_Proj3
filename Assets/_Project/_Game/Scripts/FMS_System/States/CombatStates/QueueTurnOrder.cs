using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class QueueTurnOrder : CombatState
{
    [SerializeField] Text _stateText;
    bool _activated = false;

    List<CharacterController> _characters = 
        new List<CharacterController>();

    public override void Enter()
    {
        _stateText.text = "Queue Turn Order State";
        _stateText.gameObject.SetActive(true);

        _activated = false;

        _combatStateMachine.Input.PressedConfirmed += InputAction;


        CheckVictoryCondition();
        GetNextCharacter();
    }

    void GetNextCharacter()
    {
        if (_combatStateMachine._combatants.Count < 0)
            print("no combantants present");
            //_combatStateMachine.ChangeState<>();
        _combatStateMachine._characterTarget = _combatStateMachine._combatants[0];
        //Find Next Character Turn
    }

    void CheckVictoryCondition()
    {
        int allyCount = 0;
        int enemyCount = 0;
        for(int i = 0; i < _combatStateMachine._combatants.Count; i++)
        {
            if (_combatStateMachine._combatants[i].GetType() == typeof(PlayerController))
            {
                allyCount++;
            }
            else if(_combatStateMachine._combatants[i].GetType() == typeof(EnemyController))
            {
                enemyCount++;
            }

        }


        print(allyCount);
        print(enemyCount);
        //If no enemies are present Achieve Win State
        //If no players are present Achieve Lose State
    }

    void InputAction()
    {
        _stateMachine.ChangeState<TurnState>();
    }

    public override void Exit()
    {
        _stateText.gameObject.SetActive(false);

        _combatStateMachine.Input.PressedConfirmed -= InputAction;

        _activated = false;
    }
}