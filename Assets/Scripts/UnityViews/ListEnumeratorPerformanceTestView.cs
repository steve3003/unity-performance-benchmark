using System;
using System.Collections.Generic;
using UnityEngine;

public class ListEnumeratorPerformanceTestView : UnityViewBase
{
    public enum EnumeratorType
    {
        Enumerator,
        ListEnumerator,
    }

    [SerializeField]
    private EnumeratorType enumeratorType;
    [SerializeField]
    private ListBuilderView listBuilder;

    protected override IPerformanceTest InitView()
    {
        switch (listBuilder.Type)
        {
            case ObjectType.Int:
                return CreateTest<int>();
        }
        throw new NotImplementedException(string.Format("listType {0} is not supported", listBuilder.Type));
    }

    private IPerformanceTest CreateTest<T>()
    {
        List<T> list = listBuilder.Build<T>();
        switch (enumeratorType)
        {
            case EnumeratorType.Enumerator:
                return new EnumeratorPerformanceTest<T>(list);
            case EnumeratorType.ListEnumerator:
                return new ListEnumeratorPerformanceTest<T>(list);
        }
        throw new NotImplementedException(string.Format("enumeratorType {0} is not supported", enumeratorType));
    }
}
