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

    void ShuffleQueue()
    {
        _combatStateMachine._combatants.RemoveAt(0);
        _combatStateMachine._combatants.Add(_combatStateMachine._characterTarget);

        for (int i = 0; i < _combatStateMachine._combatants.Count; i++)
            print(_combatStateMachine._combatants[i]);

        if(_combatStateMachine._characterTarget == _combatStateMachine._combatants[0])
        {

        }
    }

    void GetNextCharacter()
    {
        if (_combatStateMachine._combatants.Count < 0)
        {
            print("no combantants present");
            WonBattle();
        }

        _combatStateMachine._characterTarget = _combatStateMachine._combatants[0];
        ShuffleQueue();
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

        if (allyCount <= 0)
            GameOver();
        if (enemyCount <= 0)
            WonBattle();
    }

    void GameOver()
    {
        print("gameover");
    }

    void WonBattle()
    {
        print("won battle");
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