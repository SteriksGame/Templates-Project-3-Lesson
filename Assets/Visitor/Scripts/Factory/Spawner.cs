using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, IEnemyDeathNotifier, IEnemySpawnNotifier
{
    public event Action<Enemy> SpawnNotified;
    public event Action<Enemy> DeadNotified;

    [SerializeField] private float _spawnCooldown;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private EnemyFactory _enemyFactory;

    private List<Enemy> _spawnedEnemies = new List<Enemy>();

    private Coroutine _spawn;

    private Weight _weight;

    public void StartWork()
    {
        StopWork();

        _weight = new Weight(this, this);

        _spawn = StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_spawn != null)
            StopCoroutine(_spawn);
    }

    // В реальной игре такого метода тут быть не должно!
    public void KillRandomEnemy()
    {
        if (_spawnedEnemies.Count == 0)
            return;

        _spawnedEnemies[UnityEngine.Random.Range(0, _spawnedEnemies.Count)].Kill();
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            if (_weight.IsMaxWeight())
            {
                StopWork();
                break;
            }

            Enemy enemy = _enemyFactory.Get((EnemyTypes)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyTypes)).Length));
            enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);

            enemy.Spawn += OnEnemySpawn;
            enemy.Died += OnEnemyDied;

            _spawnedEnemies.Add(enemy);

            yield return new WaitForSeconds(_spawnCooldown);
        }
    }

    private void OnEnemySpawn(Enemy enemy)
    {
        SpawnNotified?.Invoke(enemy);

        enemy.Spawn -= OnEnemySpawn;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        DeadNotified?.Invoke(enemy);

        enemy.Died -= OnEnemyDied;
        _spawnedEnemies.Remove(enemy);
    }
}
