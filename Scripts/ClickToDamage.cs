using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDamage : MonoBehaviour
{
    [SerializeField] PlayerStatsScriptableObject stats;
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = transform.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Click to damage!
    void OnMouseDown() 
    {
        if (health != null)
            health.takeDamage(stats.clickDamage);
    } 
}
