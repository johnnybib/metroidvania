using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private float duration = 0.5f;
    private float elapsedTime = 0;
    private float damage = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(elapsedTime >= duration)
        {
            Destroy(this.gameObject);
        }
        elapsedTime += Time.deltaTime;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void SetDuration(float duration)
    {
        this.duration = duration;
    }
    
    public float GetDamage()
    {
        return damage;
    }
}
