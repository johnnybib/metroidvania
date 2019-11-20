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
        input.GetInput();
        EnemyState newState1 = state.HandleInput(this, input);
        EnemyState newState2 = state.Update(this, input);

        if(newState2 == null)
        {
            if(newState1!=null)
            {
                state = newState1;
                state.StateEnter(this);
            }
        }
        else
        {
            state = newState2;
            state.StateEnter(this);

        }
    }
}

