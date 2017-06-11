using System.Collections.Generic;
using UnityEngine;

public class DictionaryEnumeratorPerformanceTest<TKey, TValue> : IPerformanceTest
{
    private readonly Dictionary<TKey, TValue> dictionary;

    public DictionaryEnumeratorPerformanceTest(Dictionary<TKey, TValue> dictionary)
    {
        this.dictionary = dictionary;
    }

    void IPerformanceTest.Run()
    {
        var enumerator = dictionary.GetEnumerator();
        while (enumerator.MoveNext())
        {
#pragma warning disable 219
            var current = enumerator.Current;
#pragma warning restore 219
        }
    }
}
