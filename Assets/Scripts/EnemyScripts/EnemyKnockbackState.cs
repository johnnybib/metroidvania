using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockbackState : EnemyState
{

    private const int KNOCKBACKFRAMES = 20;
    private int knockBackFrameCounter = 0;
    private bool entered = true;
    private Vector3 dir;
    private float knockback;

    public EnemyKnockbackState(Vector3 dir, float knockback)
    {
        this.dir = dir;
        this.knockback = knockback;
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
            Vector3 knockbackForce = dir;
            knockbackForce.y = 1 * knockback;
            knockbackForce.x = -Mathf.Sign(knockbackForce.x) * knockback;
            Debug.Log(knockbackForce);
            p.body.AddForce(knockbackForce);
        }
        knockBackFrameCounter++;
        if(knockBackFrameCounter == KNOCKBACKFRAMES)
        {
            return new EnemyFallingState();
        }   
        return null;
    }
}
