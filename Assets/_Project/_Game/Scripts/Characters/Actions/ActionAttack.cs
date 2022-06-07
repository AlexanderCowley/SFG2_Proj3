using UnityEngine;
using UnityEngine.UI;

public class ActionAttack : ActionBase
{
    Button _btn;

    IDamagable _damagableTarget;

    [SerializeField] int _damage;
    [SerializeField] int _stunDamage;

    CombatSelection _selection;
    void Awake()
    {
        _btn = GetComponent<Button>();
        _selection = GetComponentInParent<CombatSelection>();
    }

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