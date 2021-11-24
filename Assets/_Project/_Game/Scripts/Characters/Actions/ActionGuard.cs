using UnityEngine;
using UnityEngine.UI;

public class ActionGuard : MonoBehaviour
{
    Button _btn;
    TurnState _turnState;
    Health _health;
    [SerializeField] int _guardValue;
    void Awake()
    {
        _btn = GetComponent<Button>();
        _health = transform.root.GetComponentInParent<Health>();
    }

    private void OnEnable() => _btn.onClick.AddListener(Guard);

    private void OnDisable() => _btn.onClick.RemoveListener(Guard);

    public void GetTurnState(TurnState turnState) => _turnState = turnState;

    void Guard()
    {
        _health.IncreaseArmor(_guardValue);
        _turnState.OnSelect();
    }
}