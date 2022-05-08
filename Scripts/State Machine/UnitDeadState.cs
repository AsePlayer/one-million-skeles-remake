using UnityEngine;

public class UnitDeadState : UnitBaseState
{
    public override void EnterState(UnitStateManager unit) 
    {
        unit.animator.Play(unit.deathAnimation);
    }

    public override void UpdateState(UnitStateManager unit) 
    {
        unit.aiPath.canMove = false;
    }

    public override void OnCollisionEnter(UnitStateManager unit) 
    {
        
    }
}
