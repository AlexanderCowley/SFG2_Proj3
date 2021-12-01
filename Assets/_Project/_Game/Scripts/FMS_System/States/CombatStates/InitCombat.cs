using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InitCombat : CombatState
{
    [SerializeField] Text _stateText;

   [SerializeField] Transform _playerDestinationOrigin;
   [SerializeField] Transform _enemyDestinationOrigin;

    [SerializeField] List<CombatCharacterController> _characters = 
        new List<CombatCharacterController>();

    public override void Enter()
    {
        if (_combatStateMachine == null)
            _combatStateMachine = GetComponent<CombatStateMachine>();

        _stateText.text = "Inititalizing Combat...";

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
            Vector3 offSetVector = Vector3.zero;
            float positionOffset = ((i + 2) * 1.1f);
            Vector3 finalVector = Vector3.zero;

            if(_characters[i].GetType() == typeof(PlayerController))
            {
                print("player");
                offSetVector = new Vector3(positionOffset, _playerDestinationOrigin.localPosition.y, 0);
                finalVector = _playerDestinationOrigin.position + offSetVector;
            }
            else if(_characters[i].GetType() == typeof(EnemyController))
            {
                print("enemy");
                offSetVector = new Vector3(positionOffset, _enemyDestinationOrigin.localPosition.y, 0);
                finalVector = _enemyDestinationOrigin.position + offSetVector;
            }

            GameObject combantant = Instantiate(_characters[i].gameObject, finalVector, Quaternion.identity);
            combantant.GetComponent<CharacterStunStatus>().QueueReference(GetComponent<QueueTurnOrder>());
            _combatStateMachine._combatants.Add(combantant);
        }

        QueueCharacters();
    }

    void QueueCharacters()
    {
        _combatStateMachine._combatants.OrderByDescending(characters => 
        characters.GetComponent<CombatCharacterController>().Stats.Speed);

        _combatStateMachine._combatants.Reverse();

        StartCoroutine(stateDelay(2f));
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