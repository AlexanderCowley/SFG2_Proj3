using UnityEngine;

[CreateAssetMenu(fileName = "Character Stats", menuName = "New Character Stat")]
public class CharacterStats : ScriptableObject
{
    public int health, damage;
    public int Health => health;
    public int Damage => damage;


    public float speed;
    public float Speed => speed;
}