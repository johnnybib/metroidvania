using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashState : AttackingState
{
    public SlashState(PlayerState fromState) : base(fromState)
    {

    }

    public override void StateEnter(PlayerController p)
    {
        Debug.Log("Attack");
        p.ResetStates();
        p.anim.SetBool("slash", true);
        Vector3 pos = p.transform.position;
        pos.x += 1 * (p.isFacingRight ? 1 : -1);
        GameObject attack = GameObject.Instantiate(p.attackHitbox, pos, Quaternion.identity, p.gameObject.transform);
        attack.SendMessage("SetDamage", p.DAMAGE);
        attack.SendMessage("SetDuration", p.attackDurations["Slash"]);
    }
}
