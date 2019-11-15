using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D body;
    
    [HideInInspector]
    public Animator anim;
    public float ACCELSLOWDOWN;
    public float ACCELX;
	public float STOPTHRESH;
    public float SLOWDOWNTHRES;
	public float MAXSPEEDX;
    public float JUMPFORCE;
    public float RAYCASTDOWNDIST;

    public bool isFacingRight = false;

    public void Stop()
    {
        body.velocity = new Vector2(0, body.velocity.y);
    }

    public void CheckFlip(float horz)
    {
        if((isFacingRight && horz < 0) || (!isFacingRight && horz > 0))
        {
            Vector3 newScale = transform.localScale;
            newScale.x = -transform.localScale.x;
            transform.localScale = newScale;
            isFacingRight = !isFacingRight;
            Stop();
            // if(Mathf.Abs(p.body.velocity.x) > STOPTHRESH)
            // {
            //     isTurning = true;
            //     turningCounter = 0;
            // }
        }
    }
    public void ResetStates()
    {
        foreach(AnimatorControllerParameter param in anim.parameters)
		{
			if(param.type == AnimatorControllerParameterType.Bool)
			{
				anim.SetBool(param.name, false);
			}
		}
    }
    public bool RayCastGround()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");
        layerMask = ~layerMask;
        Vector3 currentPos = transform.position;

        if (Physics2D.Raycast(currentPos, transform.TransformDirection(Vector3.down), RAYCASTDOWNDIST, layerMask).collider == null)
        {
            Debug.DrawRay(currentPos, transform.TransformDirection(Vector3.down) * RAYCASTDOWNDIST, Color.yellow);
            return false;
        }
        else
        {
            Debug.DrawRay(currentPos, transform.TransformDirection(Vector3.down) * RAYCASTDOWNDIST, Color.red);
            return true;
        }
    }
}
