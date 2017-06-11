using System;
using System.Collections.Generic;
using UnityEngine;

public class ListForEachPerformanceTestView : UnityViewBase
{
    public enum ForEachType
    {
        Enumerable,
        List,
    }

    [SerializeField]
    private ForEachType foreachType;
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
        switch (foreachType)
        {
            case ForEachType.Enumerable:
                return new ForEachPerformanceTest<T>(list);
            case ForEachType.List:
                return new ListForEachPerformanceTest<T>(list);
        }
        throw new NotImplementedException(string.Format("foreachType {0} is not supported", foreachType));
    }
}
