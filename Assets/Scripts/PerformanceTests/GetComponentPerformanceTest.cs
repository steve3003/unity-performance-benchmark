using UnityEngine;

public class GetComponentPerformanceTest<T> : IPerformanceTest
    where T : Component
{
    private GameObject gameObject;

    public GetComponentPerformanceTest(bool existingComponent = true)
    {
        gameObject = new GameObject();
        if (existingComponent)
        {
            gameObject.AddComponent<T>();
        }
    }

    void IPerformanceTest.Run()
    {
        gameObject.GetComponent<T>();
    }
}
