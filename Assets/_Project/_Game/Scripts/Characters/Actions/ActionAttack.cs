using UnityEngine;
using UnityEngine.UI;

public class ActionAttack : MonoBehaviour
{
    Button _btn;

    IDamagable _damagableTarget;

    int _damage;
    int _stunDamage;

    CombatSelection _selection;

    TurnState _turnState;
    void Awake()
    {
        _damage = transform.root.GetComponent<CombatCharacterController>().Stats.Damage;
        _stunDamage = transform.root.GetComponent<CombatCharacterController>().Stats.StunDamage;
        _btn = GetComponent<Button>();
        _selection = GetComponentInParent<CombatSelection>();
    }

    public void GetTurnState(TurnState turnState) => _turnState = turnState;

    void OnEnable()
    {
        _btn.onClick.AddListener(StartSelection);
    }

    void OnDisable()
    {
        _btn.onClick.RemoveListener(StartSelection);
    }

    void StartSelection()
    {
        _selection.InitSelectionMode();
    }

    public void GetSelectionTarget(IDamagable damagable)
    {
        _damagableTarget = damagable;
        Attack();
    }

    void Attack()
    {
        _damagableTarget?.OnHit(_damage, _stunDamage);
        _turnState.OnSelect();
    }
}