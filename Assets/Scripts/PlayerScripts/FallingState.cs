using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : AerialState
{
    public override PlayerState HandleInput(PlayerController p, PlayerInput i)
    {
        //Do nothing
        return base.HandleInput(p, i);
    }

    public override PlayerState Update(PlayerController p, PlayerInput i)
    {        
        // Debug.Log("Falling");
        if(p.RayCastGround())
        {
            if(Mathf.Abs(i.horz) > 0)
            {
                return new WalkingState();
            }
            else
            {
                return new IdleState();
            }
        }

        return base.Update(p, i);
    }

    public override void StateEnter(PlayerController p)
    {
        p.ResetStates();
        p.anim.SetBool("falling", true);
    }
}
