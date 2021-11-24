using UnityEngine;

[CreateAssetMenu(fileName = "Character Stats", menuName = "New Character Stat")]
public class CharacterStats : ScriptableObject
{
    public int health, stunHealth, damage, stunDamage;
    public int Health => health;
    public int StunHealth => stunHealth;


    public float speed;
    public float Speed => speed;
}