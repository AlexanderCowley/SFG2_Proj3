using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class QueueTurnOrder : CombatState
{
    [SerializeField] Text _stateText;

    public override void Enter()
    {
        _stateText.text = "Queuing Turn Order...";
        _stateText.gameObject.SetActive(true);

        StartCoroutine(delaySceneChange());
    }

    IEnumerator delaySceneChange()
    {
        yield return new WaitForSeconds(2f);
        CheckCharacterStatus();
    }

    void ShuffleQueue()
    {
        _combatStateMachine._combatants.RemoveAt(0);
        _combatStateMachine._combatants.Add(_combatStateMachine._characterTarget);
        InputAction();
    }

    public void MoveCharacterInQueue(CharacterStunStatus characterStunStatus, int setBackIndex)
    {
        int index = _combatStateMachine._combatants.IndexOf(characterStunStatus.gameObject);
        _combatStateMachine._combatants.RemoveAt(index);

        if(index + setBackIndex > _combatStateMachine._combatants.Count)
            index = _combatStateMachine._combatants.Count - index;

        _combatStateMachine._combatants.Insert(index, characterStunStatus.gameObject);
        print("target stunned");
    }

    void GetNextCharacter()
    {
        if (_combatStateMachine._combatants.Count < 0)
        {
            WonBattle();
        }

        _combatStateMachine._characterTarget = _combatStateMachine._combatants[0];
        ShuffleQueue();
    }

    void CheckCharacterStatus()
    {
        for (int i = 0; i < _combatStateMachine._combatants.Count; i++)
        {
            if(_combatStateMachine._combatants[i].GetComponent<Health>()._CurrentHealth <= 0)
            {
                _combatStateMachine._combatants.RemoveAt(i);
            }
        }
            CheckVictoryCondition();
    }

    void CheckVictoryCondition()
    {
        int allyCount = 0;
        int enemyCount = 0;
        for(int i = 0; i < _combatStateMachine._combatants.Count; i++)
        {
            if (_combatStateMachine._combatants[i].GetComponent<PlayerController>() !=  null)
                allyCount++;
            else if(_combatStateMachine._combatants[i].GetComponent<EnemyController>() != null)
                enemyCount++;
        }

        if (allyCount <= 0)
            GameOver();
        if (enemyCount <= 0)
            WonBattle();
        else
            GetNextCharacter();
    }

    void GameOver()
    {
        print("game over");
        _combatStateMachine.ChangeState<LoseState>();
    }

    void WonBattle()
    {
        _combatStateMachine.ChangeState<WinState>();
    }

    void InputAction()
    {
        _combatStateMachine.ChangeState<TurnState>();
    }

    public override void Exit()
    {
        _stateText.gameObject.SetActive(false);
    }
}