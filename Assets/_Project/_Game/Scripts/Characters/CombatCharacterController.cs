using UnityEngine;

public class CombatCharacterController : MonoBehaviour
{
    [SerializeField] CharacterStats _stats;
    public CharacterStats Stats => _stats;
    public virtual void EnableInput(){}

    public virtual void DisableInput(){}
}