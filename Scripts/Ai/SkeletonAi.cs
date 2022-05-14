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
        aiDestination = GetComponent<AIDestinationSetter>();
    }

    void Start()
    {
        StartCoroutine(GetClosestEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        if(aiDestination == null)
            aiDestination = GetComponent<AIDestinationSetter>();        
    }

    IEnumerator GetClosestEnemy()
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        // Find all Heroes on screen
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Hero");
        foreach(GameObject potentialTarget in enemies)
        {
            // Get closest Hero
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
            }
        }
        // Set enemy A* destination to closest Hero
        aiDestination.target = bestTarget;
        yield return new WaitForSeconds(2);
    }

    void OnEnable()
    {
        // Enemies will ignore Enemy collision.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject evil in enemies)
        {
            Physics2D.IgnoreCollision(evil.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
