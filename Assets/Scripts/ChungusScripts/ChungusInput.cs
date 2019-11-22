using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChungusInput : EntityInput
{

    private float leftTimer = 1;
    private float timeElapsed = 0;

    public ChungusInput()
    {
        horz = 0;
    }
    
    public override void GetInput()
    {
        // if(timeElapsed >= leftTimer)
        // {
        //     int randNum = Random.Range(0, 3);
        //     if(randNum == 0)
        //     {
        //         horz = 1;
        //     }
        //     else if(randNum == 1)
        //     {
        //         horz = -1;
        //     }
        //     else
        //     {
        //         horz = 0;
        //     }

        //     timeElapsed = 0;
        // }
        // timeElapsed += Time.deltaTime;
    }
}
