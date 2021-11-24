using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    IDamagable _damagableTarget;

    [SerializeField] List<PlayerController> _characters = new List<PlayerController>();

    TurnState _turnState;

    int _damage;
    int _stunDamage;
    void Awake()
    {
        _damage = transform.GetComponentInParent<CombatCharacterController>().Stats.Damage;
        _stunDamage = transform.GetComponentInParent<CombatCharacterController>().Stats.StunDamage;
    }


    public void FindRandomTarget()
    {
        int randomIndex = Random.Range(0, _characters.Count);
        print(randomIndex);
        _damagableTarget = _characters[randomIndex].GetComponent<IDamagable>();
        Attack();
    }

    public void InitCombatList(List<GameObject> characters)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].GetComponent<PlayerController>() == null)
                continue;

            _characters.Add(characters[i].GetComponent<PlayerController>());
        }
    }

    public void InitTurnState(TurnState turnState) => _turnState = turnState;

    void Attack()
    {
        //Coroutine
        print(_damagableTarget);
        _damagableTarget?.OnHit(_damage, _stunDamage);
        _characters.Clear();
        _turnState.OnSelect();
    }
}