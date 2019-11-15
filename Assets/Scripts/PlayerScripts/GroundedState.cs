using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : PlayerState
{
    public override PlayerState HandleInput(PlayerController p, ControllerInput i)
    {
        if(!p.RayCastGround())
        {
            return new FallingState();
        }
        if(i.jumpPressed)
        {
            return new JumpSquatState();
        }
        else if(Mathf.Abs(i.horz) > 0)
        {
            return new WalkingState();
        }
        else
        {
            return new IdleState();
        }
    }

    public override PlayerState Update(PlayerController p, ControllerInput i)
    {
        return null;
    }
}
