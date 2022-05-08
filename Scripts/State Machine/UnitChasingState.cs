using UnityEngine;
using Pathfinding;


public class UnitChasingState : UnitBaseState
{
    

    public override void EnterState(UnitStateManager unit) 
    {
        unit.animator.Play(unit.walkAnimation);
    }

    public override void UpdateState(UnitStateManager unit) 
    {
        if(unit.aiPath != null)
        {
            // can no longer move (presumably because it reached the target)
            if(unit.aiPath.reachedDestination)
            {
                unit.SwitchState(unit.AttackingState);
            }
        }
    }

    public override void OnCollisionEnter(UnitStateManager unit) 
    {
        
    }
}
