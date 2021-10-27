using UnityEngine.UI;
using UnityEngine;

public class LoadLevelState : BaseState
{
    [SerializeField] Text _stateText;
    bool _activated = false;

    public override void Enter()
    {
        _stateText.text = "Level Set Up";

        _activated = false;
    }

    public override void Exit()
    {
        _activated = false;
    }

    public override void FixedTick()
    {
        
    }

    public override void Tick()
    {
        
    }
}