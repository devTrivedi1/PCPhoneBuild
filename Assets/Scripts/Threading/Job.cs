using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class Job<T>
{
    public delegate void JobFinished(T result);

    public JobFinished jobFinishedEvent;
    public abstract void Execute();

}

