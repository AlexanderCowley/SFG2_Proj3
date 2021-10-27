using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class EnemyTurnState : CombatState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    [SerializeField] Text _stateText;
    public override void Enter()
    {
        _stateText.text = "Enemy Turn Start";

        EnemyTurnBegan?.Invoke();

        StartCoroutine(enemyTurnDecision(2f));
    }

    IEnumerator enemyTurnDecision(float pauseDuration)
    {
        _stateText.text = "Enemy Turn Waiting";

        yield return new WaitForSeconds(pauseDuration);

        EnemyTurnEnded?.Invoke();
        _stateMachine.ChangeState<TurnState>();
    }

    public override void Exit()
    {
        
    }

    public override void Tick()
    {

    }
}