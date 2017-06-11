using System.Collections.Generic;
using UnityEngine;

public class ListEnumeratorPerformanceTest<T> : IPerformanceTest
{
    private readonly List<T> list;

    public ListEnumeratorPerformanceTest(List<T> list)
    {
        this.list = list;
    }

    void IPerformanceTest.Run()
    {
        var enumerator = list.GetEnumerator();
        while (enumerator.MoveNext())
        {
#pragma warning disable 219
            var current = enumerator.Current;
#pragma warning restore 219
        }
    }
}
