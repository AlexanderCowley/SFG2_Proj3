using UnityEngine;

[RequireComponent(typeof(CombatCharacterController))]
public class Health : MonoBehaviour, IDamagable
{
    CombatCharacterController _controller;
    int _currentHealth;

    public delegate void OnDamaged();
    public OnDamaged _hitEvent;
    public OnDamaged _stunEvent;
    public int _CurrentHealth => _currentHealth;

    int _currentStunHealth;
    public int _CurrentStunHealth => _currentStunHealth;
    void Awake()
    {
        _controller = GetComponent<CombatCharacterController>();
        _currentHealth = _controller.Stats.Health;
        _currentStunHealth = _controller.Stats.StunHealth;
    }
    public void ResetStunHealth() => _currentStunHealth = _controller.Stats.StunHealth;
    public void IncreaseArmor(int armorValue) => _currentHealth += armorValue;
    public void OnHit(int health, int stun)
    {
        _currentHealth -= health;
        _currentStunHealth -= stun;
        _hitEvent?.Invoke();
        _stunEvent?.Invoke();
    }
}