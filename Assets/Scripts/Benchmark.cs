using UnityEngine;
using UnityEngine.Networking;

public class Benchmark : MonoBehaviour
{
    [SerializeField]
    private UnityViewBase benchmark;

    private void Update()
    {
        benchmark.Run();
    }
}
