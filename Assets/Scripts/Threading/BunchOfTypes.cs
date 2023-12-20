using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunchOfTypes : Job<float>
{
    float result;

    public override void Execute()
    {
        for (int i = 0; i < 200; i++)
        {
            for (int j = 0; j < 200; j++)
            {
                result += i + j;
            }
        }

        Debug.Log(result);
        jobFinishedEvent(result);
    }
}
