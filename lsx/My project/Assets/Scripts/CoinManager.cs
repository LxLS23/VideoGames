using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get ; private set; }
    private int coins;
    public int maxCoins = 100;
    public GameObject coinPrefab;
    public Transform coinSpawn;
    public Vector3 coinRowsColumns = new Vector3(6, 0, 6);
    private void Awake()
    {
        if (Instance) Destroy(Instance.gameObject);
        Instance = this;
    }

    private void Start()
    {
        for (int x = 0; x < coinRowsColumns.x; x++)
        {
            for (int z = 0; z < coinRowsColumns.z; z++)
            {
                var instance = Instantiate(coinPrefab);
                instance.transform.position = new Vector3(x, 1.5f, z) + coinSpawn.position;

            }
        }
    }

    public void AddCoins(int amount)
    {
        coins = Mathf.Min(maxCoins, coins + amount);
        Debug.Log($"Total coins added: {coins}");
    }

    private void OnDrawGizmos()
    {
        var center = coinSpawn.position + coinRowsColumns / 2;
        center += Vector3.up * 2;
        var newSize = coinRowsColumns + Vector3.up;
        Gizmos.DrawWireCube(center,newSize);
    }
}
