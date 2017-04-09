
public class PerformanceTestSequence : IPerformanceTest
{
    private readonly IPerformanceTest[] tests;

    public PerformanceTestSequence(params IPerformanceTest[] tests)
    {
        this.tests = tests;
    }

    void IPerformanceTest.Run()
    {
        var testsLength = tests.Length;
        for (var i = 0; i < testsLength; ++i)
        {
            tests[i].Run();
        }
    }
}
