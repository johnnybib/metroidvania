using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    private PlayerState state;
    private ControllerInput input;

    public float ACCELSLOWDOWN;
    public float ACCELX;
	public float STOPTHRESH;
    public float SLOWDOWNTHRES;
	public float MAXSPEEDX;
    public float JUMPFORCE;
    public float JUMPSQUATFORCE;
    public float RAYCASTDOWNDIST;

    public bool isFacingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
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
            }
        }
        else
        {
            state = newState2;
        }
    }

    public void Stop()
    {
        body.velocity = new Vector2(0, body.velocity.y);
    }
}
