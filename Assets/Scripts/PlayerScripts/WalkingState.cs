using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : GroundedState
{

    public override PlayerState HandleInput(PlayerController p, PlayerInput i)
    {
        p.CheckFlip(i.horz);

        if(Mathf.Abs(i.horz) > 0)
        {
            p.body.AddForce(p.transform.right * Mathf.Sign(i.horz) * p.ACCELX);
        }

        //Pass to GroundedState 
        return base.HandleInput(p, i);
    }

    public override PlayerState Update(PlayerController p, PlayerInput i)
    {
        // Debug.Log("Walking");
        p.anim.SetFloat("walkingSpeed", p.body.velocity.x/p.MAXSPEEDX);
        if (Mathf.Abs(p.body.velocity.x) > p.MAXSPEEDX)
        {
            p.body.velocity = new Vector2(p.MAXSPEEDX * Mathf.Sign(p.body.velocity.x), p.body.velocity.y);
        }
        return null;

    }
    public override void StateEnter(PlayerController p)
    {
        p.ResetStates();
        p.anim.SetBool("walking", true);
    }
}
