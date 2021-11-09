using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //TurnState will get a reference to this after being assigned the subject
    //[SerializeField] CharacterStats
    private void Awake()
    {
        print("Character Spawned");
    }
    public virtual void EnableInput(){}

    public virtual void DisableInput(){}
}