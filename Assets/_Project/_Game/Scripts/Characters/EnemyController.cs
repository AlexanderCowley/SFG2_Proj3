using UnityEngine;

public class EnemyController : CombatCharacterController
{
    public delegate void OnTurnEntered();
    public OnTurnEntered _turnEnteredEvent;

    [SerializeField] GameObject _actionObj;
    private void Awake()
    {
        _actionObj.SetActive(false);
    }
    public override void EnableInput() => _actionObj.SetActive(true);

    public override void DisableInput() => _actionObj.SetActive(false);
}