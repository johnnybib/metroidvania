using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkingState : EnemyGroundedState
{

    public override EnemyState HandleInput(EntityController e, EntityInput i)
    {
        e.CheckFlip(i.horz);

        if(Mathf.Abs(i.horz) > 0)
        {
            e.body.AddForce(e.transform.right * Mathf.Sign(i.horz) * e.ACCELX);
        }

        //Pass to GroundedState 
        return base.HandleInput(e, i);
    }

    public override EnemyState Update(EntityController e, EntityInput i)
    {
        e.anim.SetFloat("walkingSpeed", e.body.velocity.x/e.MAXSPEEDX);
        if (Mathf.Abs(e.body.velocity.x) > e.MAXSPEEDX)
        {
            e.body.velocity = new Vector2(e.MAXSPEEDX * Mathf.Sign(e.body.velocity.x), e.body.velocity.y);
        }
        return null;

    }
    public override void StateEnter(EntityController e)
    {
        e.ResetStates();
        e.anim.SetBool("walking", true);
    }
}
