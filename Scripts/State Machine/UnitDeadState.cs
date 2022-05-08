using UnityEngine;

public class UnitDeadState : UnitBaseState
{
    public override void EnterState(UnitStateManager unit) 
    {
        unit.animator.Play(unit.deathAnimation);
        unit.aiPath.canMove = false;
    }

    public override void UpdateState(UnitStateManager unit) 
    {
        
    }

    public override void OnCollisionEnter(UnitStateManager unit) 
    {
        
    }
}
