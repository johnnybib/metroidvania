using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashState : AttackingState
{

    private string animName = "Slash";
    public SlashState(PlayerState fromState, PlayerInput i) : base(fromState, i)
    {

    }

    public override void StateEnter(PlayerController p)
    {

        Vector3 pos = p.transform.position;
        Quaternion rot = Quaternion.identity;
        if (p.anim.GetCurrentAnimatorStateInfo(0).IsName(animName))
        {
            //Can't attack
            return;
        }
        if(i.vert != 0)
        {
            if(i.vert > 0)
            {
                pos.y += 1;
                rot = rot * Quaternion.Euler(0, 0, 90 * (p.isFacingRight ? 1 : -1));
                Debug.Log("Rotate up");

            }
            else if(fromState.GetBaseStateID() == "AerialState")
            {
                pos.y -= 1;
                rot = rot * Quaternion.Euler(0, 0, -90 * (p.isFacingRight ? 1 : -1));

            }
            else
            {
                //Can't attack
                return;
            }
        }
        else
        {
            pos.x += 1 * (p.isFacingRight ? 1 : -1);
        }

        Debug.Log("Attack");
        p.ResetStates();
        p.anim.SetBool("slash", true);
        GameObject attack = GameObject.Instantiate(p.attackHitbox, pos, rot, p.gameObject.transform);
        attack.SendMessage("SetDamage", p.DAMAGE);
        attack.SendMessage("SetKnockback", p.attackKnockbacks[animName]);
        attack.SendMessage("SetDuration", p.attackDurations[animName]);
        

    }
}
