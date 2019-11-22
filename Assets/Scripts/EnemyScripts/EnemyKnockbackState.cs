using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockbackState : EnemyState
{

    private const int KNOCKBACKFRAMES = 10;
    private int knockBackFrameCounter = 0;
    private bool entered = true;
    private Vector3 force;

    public EnemyKnockbackState(Vector3 force)
    {
        this.force = force;
    }

    public override EnemyState HandleInput(EntityController p, EntityInput i)
    {
        //Do nothing
        return null;
    }

    public override EnemyState Update(EntityController p, EntityInput i)
    {        
        //Run once
        if(entered)
        {
            entered = false;
            force.y = 1 * p.KNOCKBACK;
            force.x = Mathf.Sign(force.x) * p.KNOCKBACK;
            Debug.Log(force);
            p.body.AddForce(force);
        }
        knockBackFrameCounter++;
        if(knockBackFrameCounter == KNOCKBACKFRAMES)
        {
            return new EnemyFallingState();
        }   
        return null;
    }
}
