using System;
using System.Collections.Generic;
using UnityEngine;

public class NullCheckPerformanceTest<T> : IPerformanceTest
{
    private T obj;
    private INullChecker<T> nullChecker;

    protected bool isNull;

    public NullCheckPerformanceTest(T obj, INullChecker<T> nullChecker = null)
    {
        if (nullChecker == null)
        {
            nullChecker = new DefaultNullChecker<T>();
        }
        this.nullChecker = nullChecker;
        this.obj = obj;
    }

    void IPerformanceTest.Run()
    {
        isNull = nullChecker.IsNull(obj);

        // This is for checking the Correctness of the nullChecker,
        // avoid to enable this if the test is run with many iteration per frame
        //
        //var objectNull = obj as UnityEngine.Object == null;
        //if (objectNull != isNull)
        //{
        //    Debug.LogErrorFormat("nullChecker {0} resurned {1} but the correct value is {2}", nullChecker.GetType(), isNull, objectNull);
        //}
    }
}

public class DefaultNullChecker<T> : INullChecker<T>
{
    bool INullChecker<T>.IsNull(T obj)
    {
        // this returns incorrect results in editor. It's ok in builds
        // see http://bonusdisc.com/null-references-in-unity/
        return obj == null;
    }
}

public interface INullChecker<T>
{
    bool IsNull(T obj);
}
