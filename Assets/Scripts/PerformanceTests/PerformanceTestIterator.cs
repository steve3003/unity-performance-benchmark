
public class PerformanceTestIterator : IPerformanceTest
{
    private readonly int iterations;
    private readonly IPerformanceTest test;

    public PerformanceTestIterator(int iterations, IPerformanceTest test)
    {
        this.iterations = iterations;
        this.test = test;
    }

    void IPerformanceTest.Run()
    {
        for (var i = 0; i < iterations; ++i)
        {
            test.Run();
        }
    }
}
