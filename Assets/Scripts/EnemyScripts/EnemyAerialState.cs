using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAerialState : EnemyState
{
     public override EnemyState HandleInput(EntityController e, EntityInput i)
    {
        e.CheckFlip(i.horz);
        //Do nothing
        if(Mathf.Abs(i.horz) > 0)
        {
            e.body.AddForce(e.transform.right * Mathf.Sign(i.horz) * e.ACCELX);
            if (Mathf.Abs(e.body.velocity.x) > e.MAXSPEEDX)
            {
                e.body.velocity = new Vector2(e.MAXSPEEDX * Mathf.Sign(e.body.velocity.x), e.body.velocity.y);
            }
        }
        else
        {
            if(Mathf.Abs(e.body.velocity.x) <= e.SLOWDOWNTHRES && Mathf.Abs(e.body.velocity.x) > e.STOPTHRESH)
            {
                e.body.AddForce(new Vector2 (Mathf.Sign(e.body.velocity.x), 0) * -e.ACCELSLOWDOWN);
            }
            else
            {
                e.Stop();
            }
        }

        return null;
    }

    public override EnemyState Update(EntityController e, EntityInput i)
    {
        return null;
    }
}
