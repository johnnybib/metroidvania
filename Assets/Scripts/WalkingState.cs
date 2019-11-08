using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : GroundedState
{

    public override PlayerState HandleInput(PlayerController p, ControllerInput i)
    {
        if((p.isFacingRight && i.horz < 0) || (!p.isFacingRight && i.horz > 0))
        {
            Vector3 newScale = p.transform.localScale;
            newScale.x = -p.transform.localScale.x;
            p.transform.localScale = newScale;
            p.isFacingRight = !p.isFacingRight;
            p.Stop();
            // if(Mathf.Abs(p.body.velocity.x) > STOPTHRESH)
            // {
            //     isTurning = true;
            //     turningCounter = 0;
            // }
        }

        if(Mathf.Abs(i.horz) > 0)
        {
            p.body.AddForce(p.transform.right * Mathf.Sign(p.transform.localScale.x) * p.ACCELX);
        }

        //Pass to GroundedState
        return base.HandleInput(p, i);
    }

    public override PlayerState Update(PlayerController p, ControllerInput i)
    {
        Debug.Log("Walking");
        if (Mathf.Abs(p.body.velocity.x) > p.MAXSPEEDX)
        {
            p.body.velocity = new Vector2(p.MAXSPEEDX * Mathf.Sign(p.body.velocity.x), p.body.velocity.y);
        }
        return null;

    }
}
