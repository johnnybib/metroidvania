﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : AerialState
{
    public override PlayerState HandleInput(PlayerController p, ControllerInput i)
    {
        //Do nothing
        return base.HandleInput(p, i);
    }

    public override PlayerState Update(PlayerController p, ControllerInput i)
    {        
        Debug.Log("Falling");
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

        return null;
    }

    public override void StateEnter(PlayerController p)
    {
        p.ResetStates();
        p.anim.SetBool("falling", true);
    }
}