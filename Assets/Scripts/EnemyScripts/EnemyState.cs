using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    public virtual EnemyState HandleInput(EnemyController e, EnemyInput i) {return null;}
    public virtual EnemyState Update(EnemyController e, EnemyInput i) {return null;}
    public virtual void StateEnter(EnemyController e){}

}
