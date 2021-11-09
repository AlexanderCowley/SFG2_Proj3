using UnityEngine;

public class LevelStateMachine : AbstractStateMachine
{
    void Start() => ChangeState<LoadLevelState>();
}