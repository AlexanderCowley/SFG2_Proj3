using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoseState : CombatState
{
    [SerializeField] Text _stateText;
    ChangeLevelState _changeLevelState;
    public override void Enter()
    {
        print("gameover");
        _stateText.text = "You Lose!";
        _changeLevelState = _combatStateMachine._changeLevel;
        _stateText.gameObject.SetActive(true);
        StartCoroutine(delaySceneChange());
    }

    IEnumerator delaySceneChange()
    {
        yield return new WaitForSeconds(3f);
        ChangeToGameOverScene();
    }

    void ChangeToGameOverScene()
    {
        _changeLevelState.GameOverScene();
    }
    public override void Exit()
    {
        _stateText.gameObject.SetActive(false);
    }
}