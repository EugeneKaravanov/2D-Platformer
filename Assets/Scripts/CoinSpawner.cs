using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _delay;

    private void Awake()
    {
        for (int i = 0;  i < transform.childCount; i++)
        {
            _spawnPoints.Add(transform.GetChild(i));
        }

        StartCoroutine(SpawnCoins(_delay));
    }

    private IEnumerator SpawnCoins(float _delay)
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            Instantiate(_coin, GetRandomSpawnPoint().position, Quaternion.identity);
            yield return wait;
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }
}
