using UnityEngine;
using UnityEngine.UI;

public class ActionAttack : MonoBehaviour
{
    Button _btn;

    IDamagable _damagable;

    int _damage;
    int _stunDamage;
    void Awake()
    {
        _damage = transform.root.GetComponent<CombatCharacterController>().Stats.Damage;
        _stunDamage = transform.root.GetComponent<CombatCharacterController>().Stats.StunDamage;
        _btn = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _btn.onClick.AddListener(Attack);
    }

    private void OnDisable()
    {
        _btn.onClick.RemoveListener(Attack);
    }

    void Attack()
    {
        //Get Target
        //Call interface method
    }
}