using System.Collections.Generic;
using UnityEngine;

public class CombatStateMachine : AbstractStateMachine
{
    [SerializeField] InputController _input;

    public ChangeLevelState _changeLevel;
    public InputController Input => _input;

    public GameObject _characterTarget;

    public List<GameObject> _combatants;

    void OnEnable() => ChangeState<InitCombat>();
}