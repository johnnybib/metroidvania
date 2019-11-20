using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : EntityInput
{

    public bool jumpPressed;
    public bool jumpHeld;
    public bool jumpReleased;
    public bool attackPressed;

    public override void GetInput()
    {
        horz = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
        jumpPressed = Input.GetButtonDown("Jump");
        jumpHeld = Input.GetButton("Jump");
        jumpReleased = Input.GetButtonUp("Jump");
        attackPressed = Input.GetButtonDown("Attack");
    }
}
