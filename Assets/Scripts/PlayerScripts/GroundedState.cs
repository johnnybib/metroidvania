using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : PlayerState
{
    public override PlayerState HandleInput(PlayerController p, PlayerInput i)
    {    
        if(i.attackPressed)
        {
            return new SlashState(this, i);
        }
        else if(!p.RayCastGround()) 
        {
            return new FallingState();
        }
        else if(i.jumpPressed)
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

    public override PlayerState Update(PlayerController p, PlayerInput i)
    {
        return null;
    }

    public override string GetBaseStateID()
    {
        return "GroundedState";
    }
}
