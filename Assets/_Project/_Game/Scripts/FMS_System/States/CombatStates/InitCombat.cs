using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitCombat : CombatState
{
    //Get List into Queue Characters (States or State Machine)
    //Spawn x amount of enemies
    [SerializeField] Text _stateText;

    [SerializeField] List<CharacterController> _characters = 
        new List<CharacterController>();

    public override void Enter()
    {
        if (_combatStateMachine == null)
            _combatStateMachine = GetComponent<CombatStateMachine>();
        //StartCoroutine(stateDelay(.1f));
        _stateText.text = "Init Combat State";

        _stateText.gameObject.SetActive(true);
        SpawnCombatants();
    }

    void QueueCharacters()
    {
        _combatStateMachine.ChangeState<QueueTurnOrder>();
    }

    public void SpawnCombatants()
    {
        for (int i = 0; i < _characters.Count; i++)
        {
            GameObject temp = Instantiate(_characters[i].gameObject, transform.position, Quaternion.identity);
            _combatStateMachine._combatants.Add(_characters[i]);
        }
        StartCoroutine(stateDelay(.15f));
    }

    IEnumerator stateDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        QueueCharacters();
    }

    public override void Exit()
    {
        _stateText.gameObject.SetActive(false);
    }

    public override void Tick()
    {
        
    }

}