using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HitRegister : MonoBehaviour
{
    UnitStateManager unit;
    AIDestinationSetter aiDestination;
    int damage = 15;
    // Start is called before the first frame update
    void Awake()
    {
        unit = transform.root.GetComponent<UnitStateManager>();
        aiDestination = transform.root.GetComponent<AIDestinationSetter>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void takeDamage()
    {
        if(!aiDestination.target)
            return;
        aiDestination.target.GetComponent<Health>().takeDamage(damage);
        
    }
}
