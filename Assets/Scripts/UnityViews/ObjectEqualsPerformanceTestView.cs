using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectEqualsPerformanceTestView : UnityViewBase
{
    public enum ComparerType
    {
        Object,
        UnityObject,
        Reference,
    }

    [SerializeField]
    private ComparerType comparerType = ComparerType.Object;
    [SerializeField]
    private Object object1 = null;
    [SerializeField]
    private Object object2 = null;

    protected override IPerformanceTest InitView()
    {
        switch (comparerType)
        {
            case ComparerType.Object:
                return new ObjectEqualsPerformanceTest<object>(object1, object2, new ObjectComparer());
            case ComparerType.UnityObject:
                return new ObjectEqualsPerformanceTest<Object>(object1, object2, new UnityObjectComparer());
            case ComparerType.Reference:
                return new ObjectEqualsPerformanceTest<Object>(object1, object2, new ReferenceComparer());
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public class ObjectComparer : IEqualityComparer<object>
{
    bool IEqualityComparer<object>.Equals(object x, object y)
    {
        return x == y;
    }

    int IEqualityComparer<object>.GetHashCode(object obj)
    {
        return obj.GetHashCode();
    }
}

public class UnityObjectComparer : IEqualityComparer<Object>
{
    bool IEqualityComparer<Object>.Equals(Object x, Object y)
    {
        return x == y;
    }

    int IEqualityComparer<Object>.GetHashCode(Object obj)
    {
        return obj.GetHashCode();
    }
}

public class ReferenceComparer : IEqualityComparer<Object>
{
    bool IEqualityComparer<Object>.Equals(Object x, Object y)
    {
        return ReferenceEquals(x, y);
    }

    int IEqualityComparer<Object>.GetHashCode(Object obj)
    {
        return obj.GetHashCode();
    }
}