using System;
using System.Collections.Generic;
using UnityEngine;

public class ListIteratePerformanceTestView : UnityViewBase
{
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
        return new ListIteratePerformanceTest<T>(list);
    }
}
