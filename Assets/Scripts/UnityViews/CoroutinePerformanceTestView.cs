using System;
using UnityEngine;
using UnityEngine.Profiling;

public class CoroutinePerformanceTestView : UnityViewBase
{
    public enum ManagerType
    {
        Unity,
        Mine,
    }

    [SerializeField]
    private ManagerType managerType = ManagerType.Unity;
    [SerializeField]
    private PerformanceTestProfiler profiler = null;

    private ICoroutineManager coroutineManager;
    private CustomSampler sampler;

    protected override IPerformanceTest InitView()
    {
        if (profiler != null)
        {
            sampler = profiler.Sampler;
        }

        switch (managerType)
        {
            case ManagerType.Unity:
                coroutineManager = new UnityCoroutineManager(this);
                return new CoroutinePerformanceTest(coroutineManager, new UnityWaitForSecondsFactory(0.5f));
            case ManagerType.Mine:
                coroutineManager = new CoroutineManager();
                return new CoroutinePerformanceTest(coroutineManager, new MyWaitForSecondsFactory(0.5f));
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    void Update()
    {
        if (sampler != null)
        {
            sampler.Begin();
        }

        coroutineManager.Update();

        if (sampler != null)
        {
            sampler.End();
        }
    }
}
