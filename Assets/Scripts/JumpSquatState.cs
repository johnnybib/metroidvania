using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSquatState : PlayerState
{
	private const int JUMPSQUATFRAMES = 4;
    private int jumpSquatFrameCounter = 0;
    public override PlayerState HandleInput(PlayerController p, ControllerInput i)
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

    public override PlayerState Update(PlayerController p, ControllerInput i)
    {
        Debug.Log("JumpSquat");
        return null;
    }
}

