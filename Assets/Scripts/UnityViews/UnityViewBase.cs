using UnityEngine;

public abstract class UnityViewBase : MonoBehaviour, IPerformanceTest
{
    private IPerformanceTest performanceTest;

    private void Awake()
    {
        performanceTest = InitView();
    }

    protected abstract IPerformanceTest InitView();

    void IPerformanceTest.Run()
    {
        Run();
    }

    public void Run()
    {
        performanceTest.Run();
    }
}
