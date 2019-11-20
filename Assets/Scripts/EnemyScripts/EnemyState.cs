using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    public virtual EnemyState HandleInput(EntityController e, EntityInput i) {return null;}
    public virtual EnemyState Update(EntityController e, EntityInput i) {return null;}
    public virtual void StateEnter(EntityController e){}

}
