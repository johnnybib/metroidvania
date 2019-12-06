using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSquatState : PlayerState
{
	private const int JUMPSQUATFRAMES = 4;
    private int jumpSquatFrameCounter = 0;
    public override PlayerState HandleInput(PlayerController p, PlayerInput i)
    {
        //Do nothing
        if(i.jumpHeld)
        {
            jumpSquatFrameCounter++;
        }
        if(jumpSquatFrameCounter == JUMPSQUATFRAMES || i.jumpReleased)
        {
            return new JumpingState(jumpSquatFrameCounter * p.JUMPSQUATFORCE);
        }
        return null;
    }

    public override PlayerState Update(PlayerController p, PlayerInput i)
    {
        // Debug.Log("JumpSquat");
        return null;
    }
}

