using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFallingState : EnemyAerialState
{
    public override EnemyState HandleInput(EnemyController e, EnemyInput i)
    {
        //Do nothing
        return base.HandleInput(e, i);
    }

    public override EnemyState Update(EnemyController e, EnemyInput i)
    {        
        if(e.RayCastGround())
        {
            if(Mathf.Abs(i.horz) > 0)
            {
                return new EnemyWalkingState();
            }
            else
            {
                return new EnemyIdleState();
            }
        }

        return null;
    }

    public override void StateEnter(EnemyController e)
    {
        e.ResetStates();
        e.anim.SetBool("falling", true);
    }
}
