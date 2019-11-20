using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackingState : PlayerState
{
    private PlayerState fromState;
    private string clipName;
    public AttackingState(PlayerState fromState)
    {
        this.fromState = fromState;
    }

    public override PlayerState HandleInput(PlayerController p, PlayerInput i)
    {    
        return fromState.HandleInput(p, i);
    }

    public override PlayerState Update(PlayerController p, PlayerInput i)
    {
        return fromState.Update(p, i);
    }
}
