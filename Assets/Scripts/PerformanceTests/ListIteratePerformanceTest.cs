using System.Collections.Generic;
using UnityEngine;

public class ListIteratePerformanceTest<T> : IPerformanceTest
{
    private readonly List<T> list;

    public ListIteratePerformanceTest(List<T> list)
    {
        this.list = list;
    }

    void IPerformanceTest.Run()
    {
        int length = list.Count;
        for (int i = 0; i < length; ++i)
        {
#pragma warning disable 219
            var current = list[i];
#pragma warning restore 219
        }
    }
}
