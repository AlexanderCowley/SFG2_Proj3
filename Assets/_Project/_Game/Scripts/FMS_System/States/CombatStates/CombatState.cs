using UnityEngine;

public class CombatState : BaseState
{
    protected CombatStateMachine _combatStateMachine;

    void Start() => _combatStateMachine = GetComponent<CombatStateMachine>();
}