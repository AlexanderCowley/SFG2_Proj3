using UnityEngine;

public class ActionBase : MonoBehaviour
{
    protected TurnState _turnState;
    public void GetTurnState(TurnState turnState) => _turnState = turnState;
}