using UnityEngine.UI;
using UnityEngine;

public class UI_TurnText : MonoBehaviour
{
    [SerializeField] Text _battleText;

    private void Awake()
    {
        _battleText.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        EnemyTurnState.EnemyTurnBegan += OnEnemyTurnBegan;
        EnemyTurnState.EnemyTurnEnded += OnEnemyTurnEnd;
    }

    void OnDisable()
    {
        EnemyTurnState.EnemyTurnBegan -= OnEnemyTurnBegan;
        EnemyTurnState.EnemyTurnEnded -= OnEnemyTurnEnd;
    }

    void OnEnemyTurnBegan()
    {
        _battleText.gameObject.SetActive(true);
    }

    void OnEnemyTurnEnd()
    {
        _battleText.gameObject.SetActive(false);
    }
}