using UnityEngine;

public class PerformanceTestSchedulerView : UnityViewBase
{
    [SerializeField]
    private UnityViewBase[] performanceTests = new UnityViewBase[0];

    protected override IPerformanceTest InitView()
    {
        return new PerformanceTestScheduler(performanceTests);
    }
}
