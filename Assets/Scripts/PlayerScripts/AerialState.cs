using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialState : PlayerState
{
    // Start is called before the first frame update
    public override PlayerState HandleInput(PlayerController p, PlayerInput i)
    {
        if(i.attackPressed)
        {
            return new SlashState(this);
        }
        p.CheckFlip(i.horz);
        //Do nothing
        if(Mathf.Abs(i.horz) > 0)
        {
            p.body.AddForce(p.transform.right * Mathf.Sign(i.horz) * p.ACCELX);
            if (Mathf.Abs(p.body.velocity.x) > p.MAXSPEEDX)
            {
                p.body.velocity = new Vector2(p.MAXSPEEDX * Mathf.Sign(p.body.velocity.x), p.body.velocity.y);
            }
        }
        else
        {
            if(Mathf.Abs(p.body.velocity.x) <= p.SLOWDOWNTHRES && Mathf.Abs(p.body.velocity.x) > p.STOPTHRESH)
            {
                p.body.AddForce(new Vector2 (Mathf.Sign(p.body.velocity.x), 0) * -p.ACCELSLOWDOWN);
            }
            else
            {
                p.Stop();
            }
        }

        return null;
    }

    public override PlayerState Update(PlayerController p, PlayerInput i)
    {
        if(p.body.velocity.y < 0)
        {
            return new FallingState();
        }
        else if(p.body.velocity.y >= 0)
        {
            return new UpwardsAerialState();
        }
        return null;
    }

}
