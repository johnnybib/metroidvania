using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialState : PlayerState
{
    // Start is called before the first frame update
    public override PlayerState HandleInput(PlayerController p, ControllerInput i)
    {
        //Do nothing
        if(Mathf.Abs(i.horz) > 0)
        {
            p.body.AddForce(p.transform.right * Mathf.Sign(i.horz) * p.ACCELX);
            if (Mathf.Abs(p.body.velocity.x) > p.MAXSPEEDX)
            {
                p.body.velocity = new Vector2(p.MAXSPEEDX * Mathf.Sign(p.body.velocity.x), p.body.velocity.y);
            }
        }
        else
        {
            if(Mathf.Abs(p.body.velocity.x) <= p.SLOWDOWNTHRES && Mathf.Abs(p.body.velocity.x) > p.STOPTHRESH)
            {
                p.body.AddForce(new Vector2 (Mathf.Sign(p.body.velocity.x), 0) * -p.ACCELSLOWDOWN);
            }
            else
            {
                p.Stop();
            }
        }

        return null;
    }

    public override PlayerState Update(PlayerController p, ControllerInput i)
    {
        if(p.body.velocity.y < 0)
        {
            int layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");
            layerMask = ~layerMask;
            Vector3 currentPos = p.transform.position;

            if (Physics2D.Raycast(currentPos, p.transform.TransformDirection(Vector3.down), p.RAYCASTDOWNDIST, layerMask).collider == null)
            {
                Debug.DrawRay(currentPos, p.transform.TransformDirection(Vector3.down) * p.RAYCASTDOWNDIST, Color.yellow);
            }
            else
            {
                Debug.DrawRay(currentPos, p.transform.TransformDirection(Vector3.down) * p.RAYCASTDOWNDIST, Color.red);
                return new IdleState();
            }
        }
        return null;
    }

}
