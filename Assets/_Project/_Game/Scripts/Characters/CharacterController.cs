using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //TurnState will get a reference to this after being assigned the subject
    //[SerializeField] CharacterStats

    public virtual void EnableInput(){}

    public virtual void DisableInput(){}
}