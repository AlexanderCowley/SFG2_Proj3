using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InitCombat : CombatState
{
    [SerializeField] Text _stateText;

    [SerializeField] List<CharacterController> _characters = 
        new List<CharacterController>();

    public override void Enter()
    {
        if (_combatStateMachine == null)
            _combatStateMachine = GetComponent<CombatStateMachine>();

        _stateText.text = "Init Combat State";

        _stateText.gameObject.SetActive(true);
        SpawnCombatants();
    }

    void QueueTurns()
    {
        _combatStateMachine.ChangeState<QueueTurnOrder>();
    }

    public void SpawnCombatants()
    {
        for (int i = 0; i < _characters.Count; i++)
        {
            Instantiate(_characters[i].gameObject, transform.position, Quaternion.identity);
            _combatStateMachine._combatants.Add(_characters[i]);
        }

        QueueCharacters();
    }

    void QueueCharacters()
    {
        _combatStateMachine._combatants.OrderByDescending(characters => characters.Stats.Speed);
        _combatStateMachine._combatants.Reverse();

        StartCoroutine(stateDelay(.2f));
    }

    IEnumerator stateDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        QueueTurns();
    }

    public override void Exit()
    {
        _stateText.gameObject.SetActive(false);
    }

}