﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{ 
    public virtual PlayerState HandleInput(PlayerController p, ControllerInput i) {return null;}
    public virtual PlayerState Update(PlayerController p, ControllerInput i) {return null;}
    public virtual void StateEnter(PlayerController p){}

}