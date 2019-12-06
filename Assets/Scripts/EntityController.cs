using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D body;
    
    [HideInInspector]
    public Animator anim;

    [HideInInspector]
    public HealthBarController healthBar;
    public float ACCELSLOWDOWN = 120;
    public float ACCELX = 50;
	public float STOPTHRESH = 1;
    public float SLOWDOWNTHRES = 2;
	public float MAXSPEEDX = 10;
    public float JUMPFORCE  = 350;
    public float RAYCASTDOWNDIST = 0.8f;
    public float MAXHEALTH = 10;
    public float HEALTH;

    public bool isFacingRight = false;
    public bool changedState = false;

    public virtual void Start()
    {
        healthBar = transform.GetComponentInChildren<HealthBarController>();
        HEALTH = MAXHEALTH;
    }
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
    public void TakeHit(Vector3 otherPos, float damage, float knockback)
    {
        HEALTH -= damage;
        healthBar.UpdateHealth(HEALTH, MAXHEALTH);

        Knockback(otherPos - transform.position, knockback);

        Debug.Log(HEALTH);
    }

    public virtual void Knockback(Vector3 dir, float knockback) {}
}
