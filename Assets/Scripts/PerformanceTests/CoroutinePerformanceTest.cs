using System;
using System.Collections;
using UnityEngine;

public class CoroutinePerformanceTest : IPerformanceTest
{
    private readonly ICoroutineManager coroutineManager;
    private readonly IFactory<object> yieldInstructionFactory;

    public CoroutinePerformanceTest(
        ICoroutineManager coroutineManager,
        IFactory<object> yieldInstructionFactory)
    {
        this.coroutineManager = coroutineManager;
        this.yieldInstructionFactory = yieldInstructionFactory;
    }

    void IPerformanceTest.Run()
    {
        coroutineManager.StartCoroutine(TestCoroutine());
    }

    IEnumerator TestCoroutine()
    {
        var yieldInstruction = yieldInstructionFactory.Create();
        int i = 0;
        while (true)
        {
            yield return yieldInstruction;
            //Debug.Log(i);
            ++i;
        }
    }
}

