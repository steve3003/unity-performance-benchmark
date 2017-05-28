using UnityEngine;
using UnityEngine.Profiling;

public class PerformanceTestProfiler : UnityViewBase
{
    [SerializeField]
    private bool useObjectName = true;
    [SerializeField]
    private string samplerName = "sampler";
    [SerializeField]
    private UnityViewBase performanceTest;

    private CustomSampler sampler;

    void OnValidate()
    {
        if (useObjectName)
        {
            samplerName = name;
        }
    }

    protected override IPerformanceTest InitView()
    {
        sampler = CustomSampler.Create(samplerName);
        return performanceTest;
    }

    public override void Run()
    {
        sampler.Begin();

        base.Run();

        sampler.End();
    }
}
