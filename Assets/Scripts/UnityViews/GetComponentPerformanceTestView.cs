using UnityEngine;

public class GetComponentPerformanceTestView<T> : UnityViewBase
    where T : Component
{
    [SerializeField]
    private bool existingComponent = true;

    protected override IPerformanceTest InitView()
    {
        return new GetComponentPerformanceTest<T>(existingComponent);
    }
}