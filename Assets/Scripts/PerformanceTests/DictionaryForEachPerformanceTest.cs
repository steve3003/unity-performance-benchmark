using System.Collections.Generic;

public class DictionaryForEachPerformanceTest<TKey, TValue> : IPerformanceTest
{
    private readonly Dictionary<TKey, TValue> dictionary;

    public DictionaryForEachPerformanceTest(Dictionary<TKey, TValue> dictionary)
    {
        this.dictionary = dictionary;
    }

    void IPerformanceTest.Run()
    {
        foreach (var element in dictionary)
        {
#pragma warning disable 219
            var a = element;
#pragma warning restore 219
        }
    }
}
