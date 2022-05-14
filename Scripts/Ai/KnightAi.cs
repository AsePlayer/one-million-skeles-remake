using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class KnightAi : MonoBehaviour
{
    AIDestinationSetter aiDestination;

    void Awake()
    {
        aiDestination = GetComponent<AIDestinationSetter>();
    }

    void Start()
    {
        // Start enemy AI
        StartCoroutine(GetClosestEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        if(aiDestination == null)
            aiDestination = GetComponent<AIDestinationSetter>();

        if(aiDestination.target == null || aiDestination.target.GetComponent<Health>().isDead)
            StartCoroutine(GetClosestEnemy());
    }

    IEnumerator GetClosestEnemy()
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        // Find all Enemies on screen
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject potentialTarget in enemies)
        {
            if(!potentialTarget.GetComponent<Health>().isDead)
            {
                // Get closest Enemy
                Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if(dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget.transform;
                }
            }
        }
        // Set enemy A* destination to closest Enemy
        aiDestination.target = bestTarget;
        yield return new WaitForSeconds(2);
    }
}
