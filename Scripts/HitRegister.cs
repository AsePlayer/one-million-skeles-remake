using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HitRegister : MonoBehaviour
{
    UnitStateManager unit;
    AIDestinationSetter aiDestination;
    int damage = 15;
    
    void Awake()
    {
        unit = transform.root.GetComponent<UnitStateManager>();
        aiDestination = transform.root.GetComponent<AIDestinationSetter>();
    }

    void takeDamage()
    {
        // If enemy is not dead, take the damage
        if(!aiDestination.target)
            return;
        aiDestination.target.GetComponent<Health>().takeDamage(damage);
        
    }
}
