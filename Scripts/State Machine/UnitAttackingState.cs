using UnityEngine;

public class UnitAttackingState : UnitBaseState
{
    public override void EnterState(UnitStateManager unit) 
    {
        unit.animator.Play(unit.attackAnimation);
    }

    public override void UpdateState(UnitStateManager unit) 
    {
        // is enemy
        if(unit.aiPath != null)
        {
            // can no longer move (presumably because it reached the target)
            if(!unit.aiPath.reachedDestination)
            {
                unit.SwitchState(unit.ChasingState);
            }
        }
    }

    public override void OnCollisionEnter(UnitStateManager unit) {
        
    }

    public void doDamage() 
    {
        
    }
}
