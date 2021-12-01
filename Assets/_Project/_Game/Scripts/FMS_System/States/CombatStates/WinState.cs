using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinState : CombatState
{
    [SerializeField] Text _stateText;
    ChangeLevelState _changeLevelState;
    public override void Enter()
    {
        _stateText.text = "You Won!";
        _changeLevelState = _combatStateMachine._changeLevel;
        _stateText.gameObject.SetActive(true);
        StartCoroutine(delaySceneChange());
    }

    IEnumerator delaySceneChange()
    {
        yield return new WaitForSeconds(2f);
        ChangeToWinScene();
    }

    void ChangeToWinScene()
    {
        _changeLevelState.WinScene();
    }
    public override void Exit()
    {
        _stateText.gameObject.SetActive(false);
    }
}