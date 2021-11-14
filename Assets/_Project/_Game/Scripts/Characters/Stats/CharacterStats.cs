using UnityEngine;

[CreateAssetMenu(fileName = "Character Stats", menuName = "New Character Stat")]
public class CharacterStats : ScriptableObject
{
    public int health, damage, stunDamage;
    public int Health => health;
    public int Damage => damage;
    public int StunDamage=> stunDamage;


    public float speed;
    public float Speed => speed;
}