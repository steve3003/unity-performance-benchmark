using System;
using UnityEngine;
using UnityEngine.Networking;
using Object = UnityEngine.Object;

public class NetworkSpawnPerformanceTest : IPerformanceTest
{
    private enum SpawnState
    {
        Spawn,
        UnSpawm
    }

    private SpawnState spawnState;
    private readonly GameObject objectInstance;

    public NetworkSpawnPerformanceTest(NetworkIdentity prefab)
    {
        spawnState = SpawnState.Spawn;

        objectInstance = Object.Instantiate(prefab.gameObject);
        objectInstance.SetActive(false);
        ClientScene.RegisterSpawnHandler(prefab.assetId, SpawnHandler, UnSpawnHandler);
    }

    private static void UnSpawnHandler(GameObject spawned)
    {
        spawned.SetActive(false);
    }

    private GameObject SpawnHandler(Vector3 position, NetworkHash128 assetid)
    {
        objectInstance.transform.position = position;
        objectInstance.SetActive(true);
        return objectInstance;
    }

    void IPerformanceTest.Run()
    {
        switch (spawnState)
        {
            case SpawnState.Spawn:
                Spawn();
                spawnState = SpawnState.UnSpawm;
                break;

            case SpawnState.UnSpawm:
                UnSpawn();
                spawnState = SpawnState.Spawn;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void UnSpawn()
    {
        NetworkServer.UnSpawn(objectInstance);
    }

    private void Spawn()
    {
        NetworkServer.Spawn(objectInstance);
    }
}
