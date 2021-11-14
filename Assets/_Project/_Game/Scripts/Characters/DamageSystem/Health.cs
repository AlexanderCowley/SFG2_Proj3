using UnityEngine;

[RequireComponent(typeof(CombatCharacterController))]
public class Health : MonoBehaviour, IDamagable
{
    CombatCharacterController _controller;
    private void Awake() => _controller = GetComponent<CombatCharacterController>();
    public void OnHit(int health, int stun)
    {
        _controller.Stats.health -= health;
        _controller.Stats.stunDamage -= stun;
    }
}