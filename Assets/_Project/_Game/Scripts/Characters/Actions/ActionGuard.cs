using UnityEngine;
using UnityEngine.UI;

public class ActionGuard : ActionBase
{
    Button _btn;
    Health _health;
    [SerializeField] int _guardValue;
    void Awake()
    {
        _btn = GetComponent<Button>();
        _health = transform.root.GetComponentInParent<Health>();
    }

    private void OnEnable() => _btn.onClick.AddListener(Guard);

    private void OnDisable() => _btn.onClick.RemoveListener(Guard);

    void Guard()
    {
        _health.IncreaseArmor(_guardValue);
        _turnState.OnSelect();
    }
}