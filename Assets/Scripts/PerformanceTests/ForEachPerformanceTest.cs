using System.Collections.Generic;

public class ForEachPerformanceTest<T> : IPerformanceTest
{
    private readonly IEnumerable<T> enumerable;

    public ForEachPerformanceTest(IEnumerable<T> enumerable)
    {
        this.enumerable = enumerable;
    }

    void IPerformanceTest.Run()
    {
        foreach (var element in enumerable)
        {
#pragma warning disable 219
            var a = element;
#pragma warning restore 219
        }
    }
}
