using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpwardsAerialState : AerialState
{
    public override PlayerState HandleInput(PlayerController p, PlayerInput i)
    {
        //Do nothing
        return base.HandleInput(p, i);
    }

    public override PlayerState Update(PlayerController p, PlayerInput i)
    {        
        Debug.Log("Moving Up");

        return base.Update(p, i);
    }
    public override void StateEnter(PlayerController p)
    {
        p.ResetStates();
        p.anim.SetBool("movingUp", true);
    }
}
