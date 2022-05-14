using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDamage : MonoBehaviour
{
    // Get player click damage
    [SerializeField] PlayerStatsScriptableObject stats;
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        // Get health component of object
        health = transform.GetComponent<Health>();
    }

    // Object gets clicked
    void OnMouseDown() 
    {
        // Make this object take click damage!
        if (health != null)
            health.takeDamage(stats.clickDamage);
    } 
}
