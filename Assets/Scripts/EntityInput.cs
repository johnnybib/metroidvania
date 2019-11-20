using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityInput
{
    public float horz;
    public float vert;
    public bool jump;
    public virtual void GetInput(){}
}
