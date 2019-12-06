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
    public Dictionary<string, float> attackKnockbacks;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        input = new PlayerInput();
        state = new IdleState();
        attackDurations = new Dictionary<string, float>();
        attackKnockbacks = new Dictionary<string, float>();
        attackKnockbacks.Add("Slash", 200f);
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
        base.Start();
    }
    void Update()
    {
        changedState = false;
        input.GetInput();
        PlayerState newState1 = state.HandleInput(this, input);
        PlayerState newState2 = state.Update(this, input);

        if(newState1 != null && !changedState)
        {
            changedState = true;
            state = newState1;
            state.StateEnter(this);

        }
        else if(newState2 !=null && !changedState)
        {
            changedState = true;
            state = newState2;
            state.StateEnter(this);
        }
    }

    public override void Knockback(Vector3 dir, float knockback)
    {
        if(state.GetStateID() != "KnockbackState")
        {
            changedState = true;
            state = new KnockbackState(dir, knockback);
            state.StateEnter(this);
        }
    }
}
