using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackState : PlayerState
{
    private const int KNOCKBACKFRAMES = 20;
    private int knockBackFrameCounter = 0;
    private bool entered = true;
    private Vector3 dir;
    private float knockback;

    public KnockbackState(Vector3 dir, float knockback)
    {
        this.dir = dir;
        this.knockback = knockback;
    }

    public override PlayerState HandleInput(PlayerController p, PlayerInput i)
    {
        //Do nothing
        return null;
    }

    public override PlayerState Update(PlayerController p, PlayerInput i)
    {        
        //Run once
        if(entered)
        {
            entered = false;
            p.body.velocity = Vector3.zero;
            Vector3 knockbackForce = dir;
            knockbackForce.y = 1 * knockback/2;
            knockbackForce.x = -Mathf.Sign(knockbackForce.x) * knockback;
            // Debug.Log(knockbackForce);
            p.body.AddForce(knockbackForce);
        }
        knockBackFrameCounter++;
        if(knockBackFrameCounter == KNOCKBACKFRAMES)
        {
            return new FallingState();
        }   
        return null;
    }

    public override void StateEnter(PlayerController p)
    {
        p.ResetStates();
        p.anim.SetBool("knockback", true);
    }

    public override string GetStateID()
    {
        return "KnockbackState";
    }

}
