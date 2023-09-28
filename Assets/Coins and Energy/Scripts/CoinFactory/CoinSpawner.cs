using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinFactory _coinFactory;
    [SerializeField] private float _timeSpawned = 1;

    private const int MIN_VALUE_POS_SPAWNER = -4;
    private const int MAX_VALUE_POS_SPAWNER = 5;
    private const float Y_VALUE_POS_SPAWNER = 0.5f;

    private const int RANDOM_LIMIT = 100;
    private int _randomTry;

    private List<Coin> _coinsSpawned = new List<Coin>();

    private Coroutine _spawnerCoroutine;

    public void Start() => StartSpawner();

    public void StartSpawner()
    {
        StopSpawner();

        _spawnerCoroutine = StartCoroutine(SpawnerTimeline());
    }

    public void StopSpawner()
    {
        if (_spawnerCoroutine != null)
            StopCoroutine(_spawnerCoroutine);
    }

    private IEnumerator SpawnerTimeline()
    {
        while (true)
        {
            SpawnCoin();

            yield return new WaitForSeconds(_timeSpawned);
        }
    }

    private void SpawnCoin()
    {
        _randomTry = RANDOM_LIMIT;

        Vector3 spawnPosition;

        do
        {
            if (_randomTry == 0)
            {
                StopSpawner();
                return;
            }

            spawnPosition = RandomPos();

            _randomTry--;
        }
        while (_coinsSpawned.Where(coin => 
        coin.transform.position.x == spawnPosition.x &&
        coin.transform.position.z == spawnPosition.z)
        .Count() != 0);

        Coin coin = _coinFactory.Get();
        coin.transform.position = spawnPosition;

        _coinsSpawned.Add(coin);
    }

    private Vector3 RandomPos() => new Vector3(
            Random.Range(MIN_VALUE_POS_SPAWNER, MAX_VALUE_POS_SPAWNER),
            Y_VALUE_POS_SPAWNER,
            Random.Range(MIN_VALUE_POS_SPAWNER, MAX_VALUE_POS_SPAWNER));
}
