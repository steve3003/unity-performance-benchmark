using UnityEngine;

public class PerformanceTestInitializerView : UnityViewBase
{
    [SerializeField]
    private UnityViewBase performanceTest;

    protected override IPerformanceTest InitView()
    {
        return new PerformanceTestInitializer(performanceTest);
    }
}
