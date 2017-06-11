using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IntKeyDictionaryForEachPerformanceTestView : UnityViewBase
{
    public enum ForEachType
    {
        Enumerable,
        Dictionary,
    }

    [SerializeField]
    private ForEachType foreachType;
    [SerializeField]
    private IntKeyDictionaryBuilderView dictionaryBuilder;

    protected override IPerformanceTest InitView()
    {
        switch (dictionaryBuilder.Type)
        {
            case ObjectType.Int:
                return CreateTest<int>();
        }
        throw new NotImplementedException(string.Format("listType {0} is not supported", dictionaryBuilder.Type));
    }

    private IPerformanceTest CreateTest<T>()
    {
        Dictionary<int, T> dictionary = dictionaryBuilder.Build<T>();
        switch (foreachType)
        {
            case ForEachType.Enumerable:
                return new ForEachPerformanceTest<KeyValuePair<int, T>>(dictionary);
            case ForEachType.Dictionary:
                return new DictionaryForEachPerformanceTest<int, T>(dictionary);
        }
        throw new NotImplementedException(string.Format("foreachType {0} is not supported", foreachType));
    }
}
