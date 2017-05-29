
public class PerformanceTestInitializer : IPerformanceTest
{
    private readonly IPerformanceTest test;

    private bool initialized = false;

    public PerformanceTestInitializer(IPerformanceTest test)
    {
        this.test = test;
    }

    void IPerformanceTest.Run()
    {
        if (initialized)
        {
            return;
        }
        initialized = true;

        test.Run();
    }
}
