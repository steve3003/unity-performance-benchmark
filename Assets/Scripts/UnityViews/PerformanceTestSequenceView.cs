using UnityEngine;

public class PerformanceTestSequenceView : UnityViewBase
{
    [SerializeField]
    private UnityViewBase[] performanceTests = new UnityViewBase[0];

    protected override IPerformanceTest InitView()
    {
        return new PerformanceTestSequence(performanceTests);
    }
}
