using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class SkeletonAi : MonoBehaviour
{
    AIDestinationSetter aiDestination;

    // Start is called before the first frame update
    void Awake()
    {
        aiDestination = transform.root.GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(aiDestination == null)
            aiDestination = transform.root.GetComponent<AIDestinationSetter>();

        if(aiDestination.target == null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Hero");
            if(enemies.Length >= 0)
            {
                aiDestination.target = GetClosestEnemy(enemies);
            }
        }
    }

    Transform GetClosestEnemy (GameObject[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(GameObject potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
            }
        }
     
        return bestTarget;
    }

    void OnEnable()
    {
        // Bullets will ignore Hole collision while Holes still maintain their physical blocking abilities for Units.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject evil in enemies)
        {
            Physics2D.IgnoreCollision(evil.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
