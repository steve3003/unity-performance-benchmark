using System.Collections.Generic;
using UnityEngine;

public class EnumeratorPerformanceTest<T> : IPerformanceTest
{
    private readonly IEnumerable<T> enumerable;

    public EnumeratorPerformanceTest(IEnumerable<T> enumerable)
    {
        this.enumerable = enumerable;
    }

    void IPerformanceTest.Run()
    {
        var enumerator = enumerable.GetEnumerator();
        while (enumerator.MoveNext())
        {
#pragma warning disable 219
            var current = enumerator.Current;
#pragma warning restore 219
        }
    }
}
