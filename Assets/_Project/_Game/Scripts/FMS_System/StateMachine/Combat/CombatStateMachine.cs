using System.Collections.Generic;
using UnityEngine;

public class CombatStateMachine : AbstractStateMachine
{
    [SerializeField] InputController _input;
    public InputController Input => _input;

    public CharacterController _characterTarget;

    public List<CharacterController> _combatants;

    void OnEnable() => ChangeState<InitCombat>();
}