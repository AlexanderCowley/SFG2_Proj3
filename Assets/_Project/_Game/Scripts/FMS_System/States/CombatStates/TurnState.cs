using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class TurnState : CombatState
{
    [SerializeField] Text _stateText;
    int _turnCount = 0;

    GameObject _turnTargetController;

    CombatSelection _combatSelection;

    ActionAttack _actionAttack;

    public override void Enter()
    {
        GetTarget();
        ControllerInit();

        if (_turnTargetController.GetComponentInChildren<EnemyAttack>() != null)
            InitEnemyAttack();

        SelectionInit();

        InitStateText();

        _combatStateMachine.Input.PressedConfirmed += ChangeState;
    }

    private void ControllerInit()
    {
        _turnTargetController.GetComponent<CombatCharacterController>().EnableInput();
    }

    void SelectionInit()
    {
        _combatSelection = _turnTargetController.GetComponent<CombatSelection>();
        _combatSelection?.InitCombatList(_combatStateMachine._combatants);
        _combatSelection?.InitInput(_combatStateMachine.Input);

        _actionAttack = _turnTargetController.GetComponentInChildren<ActionAttack>();
        _actionAttack?.GetTurnState(this);
        //Change to Selection State??
    }

    void InitEnemyAttack()
    {
        _turnTargetController?.GetComponentInChildren<EnemyAttack>().
            InitCombatList(_combatStateMachine._combatants);

        _turnTargetController?.GetComponentInChildren<EnemyAttack>().InitTurnState(this);

        _turnTargetController?.GetComponentInChildren<EnemyAttack>().FindRandomTarget();
    }

    void InitStateText()
    {
        _stateText.gameObject.SetActive(true);
        _turnCount++;

        _stateText.text = "Turn Number: " + _turnCount.ToString();
    }

    void GetTarget() => _turnTargetController = _combatStateMachine._characterTarget;

    public void OnSelect() => ChangeState();

    void ChangeState()
    {
        //Coroutine to delay state change until effects finish
        _stateMachine.ChangeState<QueueTurnOrder>();
    }

    public override void Exit()
    {
        _stateText.gameObject.SetActive(false);

        _combatStateMachine.Input.PressedConfirmed -= ChangeState;

        _turnTargetController.GetComponent<CombatCharacterController>().DisableInput();
    }
}