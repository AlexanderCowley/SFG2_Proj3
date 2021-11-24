using UnityEngine;

[RequireComponent(typeof(Health))]
public class CharacterDeath : MonoBehaviour
{
    Health _health;
    void Awake()
    {
        _health = GetComponent<Health>();
    }

    void OnEnable()
    {
        _health._hitEvent += OnDeath;
    }

    void OnDeath()
    {
        if(_health._CurrentHealth <= 0)
            gameObject.SetActive(false);
    }
}