using System.Collections.Generic;
using UnityEngine;

public class ObjectEqualsPerformanceTest<T> : IPerformanceTest
{
    private T object1;
    private T object2;
    private IEqualityComparer<T> comparer;

    protected bool isEqual;

    public ObjectEqualsPerformanceTest(T object1, T object2, IEqualityComparer<T> comparer = null)
    {
        if (comparer == null)
        {
            comparer = EqualityComparer<T>.Default;
        }
        this.comparer = comparer;
        this.object1 = object1;
        this.object2 = object2;
    }

    void IPerformanceTest.Run()
    {
        isEqual = comparer.Equals(object1, object2);
    }
}
