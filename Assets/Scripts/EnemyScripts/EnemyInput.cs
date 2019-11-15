using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput
{
    public float horz = 1;
    public float vert;
    public bool jump;

    private float leftTimer = 1;
    private float timeElapsed = 0;

    public EnemyInput()
    {

    }
    public void GetInput()
    {
        if(timeElapsed >= leftTimer)
        {
            int randNum = Random.Range(0, 3);
            if(randNum == 0)
            {
                horz = 1;
            }
            else if(randNum == 1)
            {
                horz = -1;
            }
            else
            {
                horz = 0;
            }

            timeElapsed = 0;
        }
        timeElapsed += Time.deltaTime;
    }
}
