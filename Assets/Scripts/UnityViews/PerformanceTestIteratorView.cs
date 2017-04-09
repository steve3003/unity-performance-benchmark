using UnityEngine;

public class PerformanceTestIteratorView : UnityViewBase
{
    [SerializeField]
    private UnityViewBase performanceTest;
    [SerializeField]
    private int iterations;

    protected override IPerformanceTest InitView()
    {
        return new PerformanceTestIterator(iterations, performanceTest);
    }
}
