using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChungusController : EntityController
{

    private EnemyState state;
    private ChungusInput input;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        state = new EnemyIdleState();
        input = new ChungusInput();
    }
    void Update()
    {
        changedState = false;
        input.GetInput();
        EnemyState newState1 = state.HandleInput(this, input);
        EnemyState newState2 = state.Update(this, input);

        if(newState2 != null && !changedState)
        {
            changedState = true;
            state = newState2;
            state.StateEnter(this);

        }
        else if(newState1!=null && !changedState)
        {
            changedState = true;
            state = newState1;
            state.StateEnter(this);
        }
    }

    public override void Knockback(Vector3 dir, float knockback)
    {
        changedState = true;
        state = new EnemyKnockbackState(dir, knockback);
        state.StateEnter(this);
    }
}

