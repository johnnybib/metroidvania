using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityController
{
    private PlayerState state;
    private PlayerInput input;
    public GameObject attackHitbox;
    public float JUMPSQUATFORCE;
    public float DAMAGE = 1;
    public Dictionary<string, float> attackDurations;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        input = new PlayerInput();
        state = new IdleState();
        attackDurations = new Dictionary<string, float>();
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach(AnimationClip clip in clips)
        {
            switch(clip.name)
            {
                case "Slash":
                    attackDurations[clip.name] = clip.length;
                    break;
            }
        }
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
