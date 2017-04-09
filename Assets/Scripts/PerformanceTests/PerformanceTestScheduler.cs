
public class PerformanceTestScheduler : IPerformanceTest
{
    private readonly IPerformanceTest[] tests;
    private int currentIndex;

    public PerformanceTestScheduler(params IPerformanceTest[] tests)
    {
        this.tests = tests;
        currentIndex = 0;
    }

    void IPerformanceTest.Run()
    {
        tests[currentIndex].Run();
        currentIndex = (currentIndex + 1) % tests.Length;
    }
}
