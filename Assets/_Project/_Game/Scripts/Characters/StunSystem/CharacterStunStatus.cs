using UnityEngine;

[RequireComponent(typeof(Health))]
public class CharacterStunStatus : MonoBehaviour
{
    Health _health;
    QueueTurnOrder _queueState;

    public delegate void OnStunned();
    public OnStunned _onStunned;
    void Awake() => _health = GetComponent<Health>();

    public void QueueReference(QueueTurnOrder queueTurnOrder) => _queueState = queueTurnOrder;

    private void OnEnable() => _health._stunEvent += StunCharacter;

    void StunCharacter()
    {
        if (_health._CurrentStunHealth <= 0)
        {
            _queueState.MoveCharacterInQueue(this, 3);
            _health.ResetStunHealth();
            _onStunned?.Invoke();
        }
            
    }
}