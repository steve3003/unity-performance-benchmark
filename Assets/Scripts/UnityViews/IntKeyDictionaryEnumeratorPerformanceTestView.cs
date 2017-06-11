using System;
using System.Collections.Generic;
using UnityEngine;

public class IntKeyDictionaryEnumeratorPerformanceTestView : UnityViewBase
{
    public enum EnumeratorType
    {
        Enumerator,
        DictionaryEnumerator,
    }

    [SerializeField]
    private EnumeratorType enumeratorType;
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
        switch (enumeratorType)
        {
            case EnumeratorType.Enumerator:
                return new EnumeratorPerformanceTest<KeyValuePair<int, T>>(dictionary);
            case EnumeratorType.DictionaryEnumerator:
                return new DictionaryEnumeratorPerformanceTest<int, T>(dictionary);
        }
        throw new NotImplementedException(string.Format("enumeratorType {0} is not supported", enumeratorType));
    }
}
