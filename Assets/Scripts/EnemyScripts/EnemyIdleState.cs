﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyGroundedState
{
    public override EnemyState HandleInput(EnemyController e, EnemyInput i)
    {
        //Do nothing
        //Pass to GroundedState
        return base.HandleInput(e, i);
    }

    public override EnemyState Update(EnemyController e, EnemyInput i)
    {
        if(Mathf.Abs(e.body.velocity.x) <= e.SLOWDOWNTHRES && Mathf.Abs(e.body.velocity.x) > e.STOPTHRESH)
        {
            e.body.AddForce(new Vector2 (Mathf.Sign(e.body.velocity.x), 0) * -e.ACCELSLOWDOWN);
        }
        else
        {
            e.Stop();
        }
        return null;
    }

    public override void StateEnter(EnemyController e)
    {
        e.ResetStates();
        e.anim.SetBool("idle", true);
    }
}