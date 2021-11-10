using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //TurnState will get a reference to this after being assigned the subject
    [SerializeField] CharacterStats _stats;
    public CharacterStats Stats => _stats;
    private void Awake()
    {
        print("Character Spawned");
    }

    public virtual void EnableInput(){}

    public virtual void DisableInput(){}
}