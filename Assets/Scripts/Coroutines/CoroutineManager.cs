using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : ICoroutineManager
{
    private readonly List<IEnumerator> coroutines = new List<IEnumerator>(10000);

    IEnumerator ICoroutineManager.StartCoroutine(IEnumerator coroutine)
    {
        var moveNext = MoveNext(coroutine);
        if (!moveNext)
        {
            return null;
        }
        coroutines.Add(coroutine);
        return coroutine;
    }

    void ICoroutineManager.StopCoroutine(IEnumerator coroutineToRemove)
    {
        var coroutinesCount = coroutines.Count;
        for (var i = coroutinesCount - 1; i >= 0; --i)
        {
            var coroutine = coroutines[i];
            if (coroutine == coroutineToRemove)
            {
                coroutines.RemoveAt(i);
                return;
            }
        }
    }

    void ICoroutineManager.StopAllCoroutines()
    {
        coroutines.Clear();
    }

    void ICoroutineManager.Update()
    {
        MyYieldInstruction.Time = Time.time;

        var coroutinesCount = coroutines.Count;
        for (var i = coroutinesCount - 1; i >= 0; --i)
        {
            var coroutine = coroutines[i];
            var moveNext = MoveNext(coroutine);
            if (!moveNext)
            {
                coroutines.RemoveAt(i);
            }
        }
    }

    private static bool MoveNext(IEnumerator coroutine)
    {
        var current = coroutine.Current;
        var enumerator = current as IEnumerator;
        bool moveNext;
        if (enumerator != null)
        {
            moveNext = MoveNext(enumerator);
            if (moveNext)
            {
                return true;
            }
        }

        moveNext = coroutine.MoveNext();
        if (moveNext)
        {
            return true;
        }

        var isYieldInstruction = coroutine is MyYieldInstruction;
        if (isYieldInstruction)
        {
            coroutine.Reset();
        }

        return false;
    }
}