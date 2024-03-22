using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private Item _item;
    [SerializeField] private float _delay;

    private List<Transform> _spawnPoints = new List<Transform>();

    private void Awake()
    {
        for (int i = 0;  i < transform.childCount; i++)
        {
            _spawnPoints.Add(transform.GetChild(i));
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnItems(_delay));
    }

    private IEnumerator SpawnItems(float _delay)
    {
        var wait = new WaitForSeconds(_delay);

        while (true)
        {
            Instantiate(_item, GetRandomSpawnPoint().position, Quaternion.identity);
            yield return wait;
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }
}
