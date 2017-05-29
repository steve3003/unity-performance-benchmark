using System;
using System.Collections;
using UnityEngine;

public class UnityCoroutineManager : ICoroutineManager
{
    private readonly MonoBehaviour monoBehaviour;

    public UnityCoroutineManager(MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour;
    }

    IEnumerator ICoroutineManager.StartCoroutine(IEnumerator coroutine)
    {
        monoBehaviour.StartCoroutine(coroutine);
        return null;
    }

    void ICoroutineManager.StopCoroutine(IEnumerator coroutineToRemove)
    {
        throw new NotImplementedException();
    }

    void ICoroutineManager.StopAllCoroutines()
    {
        monoBehaviour.StopAllCoroutines();
    }

    void ICoroutineManager.Update()
    {
    }
}