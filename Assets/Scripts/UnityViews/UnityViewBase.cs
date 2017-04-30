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

    public virtual void Run()
    {
        performanceTest.Run();
    }
}
