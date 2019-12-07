using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackingState : PlayerState
{
    public PlayerState fromState;
    public PlayerInput i;
    private string clipName;
    public AttackingState(PlayerState fromState, PlayerInput i)
    {
        this.fromState = fromState;
        this.i = i;
    }

    public override PlayerState HandleInput(PlayerController p, PlayerInput i)
    {    
        return fromState;
    }

    public override PlayerState Update(PlayerController p, PlayerInput i)
    {
        return fromState;
    }
}
