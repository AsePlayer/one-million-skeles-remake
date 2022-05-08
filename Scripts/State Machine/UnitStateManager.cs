using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class UnitStateManager : MonoBehaviour
{

    UnitBaseState currentState;
    public UnitChasingState ChasingState = new UnitChasingState();
    public UnitAttackingState AttackingState = new UnitAttackingState();
    public UnitDeadState DeadState = new UnitDeadState();

    public AIPath aiPath;
    public Animator animator;

    public string attackAnimation;
    public string walkAnimation;
    public string deathAnimation;

    
    void Awake()
    {
        aiPath = transform.root.GetComponent<AIPath>();
        animator = GetComponentInChildren<Animator>();
    }
    
    void Start()
    {
        // starting state for the state machine
        currentState = ChasingState;
        // "this" is a reference to the context (this EXACT Monobehavior script)
        currentState.EnterState(this);

    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);

        if(aiPath.target.transform.position.x > transform.position.x)
        {
            transform.root.transform.rotation = Quaternion.Euler(new Vector3 (0, -180, 0));
        }
        else
        {
            transform.root.transform.rotation = Quaternion.Euler(new Vector3 (0, 0 ,0));
        }
    }

    public void SwitchState(UnitBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void die()
    {
        SwitchState(DeadState);
        Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0)[0].clip.length / 1.25f);
    }
}
