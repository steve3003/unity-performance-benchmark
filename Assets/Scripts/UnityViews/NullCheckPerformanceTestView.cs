using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

public class NullCheckPerformanceTestView : UnityViewBase
{
    public enum ComparerType
    {
        Object,
        UnityObject,
        MyNullChecker,
        Reference
    }

    [SerializeField]
    private ComparerType comparerType = ComparerType.Object;
    [SerializeField]
    private Object obj = null;

    protected override IPerformanceTest InitView()
    {
        switch (comparerType)
        {
            case ComparerType.Object:
                return new NullCheckPerformanceTest<object>(obj);
            case ComparerType.UnityObject:
                return new NullCheckPerformanceTest<Object>(obj, new UnityObjectNullChecker());
            case ComparerType.MyNullChecker:
                return new NullCheckPerformanceTest<Object>(obj, new MyUnityObjectNullChecker());
            case ComparerType.Reference:
                return new NullCheckPerformanceTest<Object>(obj, new ReferenceNullChecker());
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public class UnityObjectNullChecker : INullChecker<Object>
{
    bool INullChecker<Object>.IsNull(Object obj)
    {
        return obj == null;
    }
}

public class MyUnityObjectNullChecker : INullChecker<Object>
{
    private static readonly MethodInfo IsNativeObjectAliveMethodInfo =
        typeof(Object).GetMethod(
            "IsNativeObjectAlive",
            BindingFlags.DeclaredOnly |
            BindingFlags.Static |
            BindingFlags.NonPublic |
            BindingFlags.InvokeMethod);

    private static readonly Func<Object, bool> IsNativeObjectAlive =
        (Func<Object, bool>)
            Delegate.CreateDelegate(typeof(Func<Object, bool>), IsNativeObjectAliveMethodInfo);

    bool INullChecker<Object>.IsNull(Object obj)
    {
        if ((object)obj == null)
        {
            return true;
        }
        return !IsNativeObjectAlive(obj);
    }
}

public class ReferenceNullChecker : INullChecker<Object>
{
    bool INullChecker<Object>.IsNull(Object obj)
    {
        // this returns incorrect results in editor. It's ok in builds
        // see http://bonusdisc.com/null-references-in-unity/
        return ReferenceEquals(obj, null);
    }
}