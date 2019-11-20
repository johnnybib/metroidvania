using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFallingState : EnemyAerialState
{
    public override EnemyState HandleInput(EntityController e, EntityInput i)
    {
        //Do nothing
        return base.HandleInput(e, i);
    }

    public override EnemyState Update(EntityController e, EntityInput i)
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

    public override void StateEnter(EntityController e)
    {
        e.ResetStates();
        e.anim.SetBool("falling", true);
    }
}
