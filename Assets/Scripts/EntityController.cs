using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D body;
    
    [HideInInspector]
    public Animator anim;
    public float ACCELSLOWDOWN = 120;
    public float ACCELX = 50;
	public float STOPTHRESH = 1;
    public float SLOWDOWNTHRES = 2;
	public float MAXSPEEDX = 10;
    public float JUMPFORCE  = 350;
    public float RAYCASTDOWNDIST = 0.8f;
    public float HEALTH = 10;
    public bool isFacingRight = false;
    public bool changedState = false;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Damage")
        {
            AttackController attackController = other.gameObject.GetComponent<AttackController>();
            float damage = attackController.GetDamage();
            HEALTH -= damage;

            Knockback(other.gameObject.GetComponentInParent(typeof(Transform)).transform.position - transform.position, attackController.GetKnockback());

            Debug.Log(HEALTH);
        }
    }

    public virtual void Knockback(Vector3 dir, float knockback) {}
}
