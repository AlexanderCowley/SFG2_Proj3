using System.Collections.Generic;
using UnityEngine;

public class InitCombat : CombatState
{
    //Get List into Queue Characters (States or State Machine)
    //Spawn x amount of enemies
    List<CharacterController> _characters = new List<CharacterController>();
    void Awake()
    {
        
    }

    void SpawnCombatants(int players, int enemies)
    {

    }


}