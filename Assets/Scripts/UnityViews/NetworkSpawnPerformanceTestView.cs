using UnityEngine;
using UnityEngine.Networking;

public class NetworkSpawnPerformanceTestView : UnityViewBase
{
    [SerializeField]
    private NetworkIdentity networkPrefab;
    [SerializeField]
    private int count = 20;

    private void Start()
    {
        if (!NetworkServer.active)
        {
            NetworkManager.singleton.StartHost();
        }
    }

    protected override IPerformanceTest InitView()
    {
        var networkSpawnTests = new IPerformanceTest[count];
        for (int i = 0; i < networkSpawnTests.Length; ++i)
        {
            networkSpawnTests[i] = new NetworkSpawnPerformanceTest(networkPrefab);
        }
        return new PerformanceTestScheduler(networkSpawnTests);
    }
}
