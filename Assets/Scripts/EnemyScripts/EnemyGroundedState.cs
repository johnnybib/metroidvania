using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundedState : EnemyState
{
    public override EnemyState HandleInput(EnemyController e, EnemyInput i)
    {
        if(!e.RayCastGround())
        {
            return new EnemyFallingState();
        }
        else if(Mathf.Abs(i.horz) > 0)
        {
            return new EnemyWalkingState();
        }
        else
        {
            return new EnemyIdleState();
        }
    }

    public override EnemyState Update(EnemyController e, EnemyInput i)
    {
        return null;
    }
}
