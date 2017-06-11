using System.Collections.Generic;

public class ListForEachPerformanceTest<T> : IPerformanceTest
{
    private readonly List<T> list;

    public ListForEachPerformanceTest(List<T> list)
    {
        this.list = list;
    }

    void IPerformanceTest.Run()
    {
        foreach (var element in list)
        {
#pragma warning disable 219
            var a = element;
#pragma warning restore 219
        }
    }
}
