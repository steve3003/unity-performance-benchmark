using System.Collections.Generic;

public class ForEachPerformanceTest : IPerformanceTest
{
    private readonly List<int> list;

    public ForEachPerformanceTest(int size)
    {
        list = new List<int>(size);
        for (var i = 0; i < size; ++i)
        {
            list.Add(0);
        }
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
