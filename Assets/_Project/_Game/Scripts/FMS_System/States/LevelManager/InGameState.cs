using UnityEngine.UI;
using UnityEngine;

public class InGameState : BaseState
{
    [SerializeField] Text _stateText;
    bool _activated = false;

    public override void Enter()
    {
        _stateText.text = "In Game Start";

        _activated = false;
    }

    public override void Exit()
    {
        print("Set complete");
        _activated = false;
    }

    public override void FixedTick()
    {

    }

    public override void Tick()
    {

    }
}