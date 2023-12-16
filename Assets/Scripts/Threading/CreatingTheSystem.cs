using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingTheSystem : MonoBehaviour
{

    private void Update()
    {
        Debug.Log("CreatingTheSystem made");
        SubmitJob();
    }
    public void SubmitJob()
    {
        Debug.Log("Submit job called");
        BunchOfTypes intType = new BunchOfTypes();
        intType.jobFinishedEvent += SubsribeToJobFinished;

        JobSystem.SubmitJob(intType);
    }

    void SubsribeToJobFinished(float result)
    {
        Debug.Log("SubscribedToJobFinished called with result: " + result);
    }
}
