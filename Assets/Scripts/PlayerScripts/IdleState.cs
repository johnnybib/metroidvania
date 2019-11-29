using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : GroundedState
{

    public override PlayerState HandleInput(PlayerController p, PlayerInput i)
    {
        //Do nothing
        //Pass to GroundedState
        return base.HandleInput(p, i);
    }

    public override PlayerState Update(PlayerController p, PlayerInput i)
    {
        // Debug.Log("Idle");
        if(Mathf.Abs(p.body.velocity.x) <= p.SLOWDOWNTHRES && Mathf.Abs(p.body.velocity.x) > p.STOPTHRESH)
        {
            p.body.AddForce(new Vector2 (Mathf.Sign(p.body.velocity.x), 0) * -p.ACCELSLOWDOWN);
        }
        else
        {
            p.Stop();
        }
        return null;
    }

    public override void StateEnter(PlayerController p)
    {
        p.ResetStates();
        p.anim.SetBool("idle", true);
    }
}
