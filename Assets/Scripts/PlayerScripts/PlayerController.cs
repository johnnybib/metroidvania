using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityController
{
    private PlayerState state;
    private ControllerInput input;
    public float JUMPSQUATFORCE;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        input = new ControllerInput();
        state = new IdleState();
    }
    void Update()
    {
        input.GetInput();
        PlayerState newState1 = state.HandleInput(this, input);
        PlayerState newState2 = state.Update(this, input);

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
