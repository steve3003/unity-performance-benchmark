using UnityEngine;

public class ForEachPerformanceTestView : UnityViewBase
{
    [SerializeField]
    private int size;

    protected override IPerformanceTest InitView()
    {
        return new ForEachPerformanceTest(size);
    }
}
