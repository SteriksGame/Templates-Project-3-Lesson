using System;
using UnityEngine;

public class Score : IDisposable
{
    private IEnemyDeathNotifier _enemyDeathNotifier;

    private EnemyVisitor _enemyVisitor;

    public Score(IEnemyDeathNotifier enemyDeathNotifier)
    {
        _enemyDeathNotifier = enemyDeathNotifier;
        _enemyDeathNotifier.DeadNotified += OnEnemyKilled;

        _enemyVisitor = new EnemyVisitor();
    }

    public int Value => _enemyVisitor.Score;

    public void Dispose()
    {
        _enemyDeathNotifier.DeadNotified -= OnEnemyKilled;
    }

    public void OnEnemyKilled(Enemy enemy)
    {
        _enemyVisitor.Visit(enemy);
        Debug.Log($"Счет: {Value}");
    }

    private class EnemyVisitor : IEnemyVisitor
    {
        public int Score { get; private set; }

        // Для работы "dynamic" необходимо переключить api level, иначе используем Accept в дочерних классах Enemy.
        // Project Settings -> Other settings -> Api Compatibility Level* -> .NET Framework
        public void Visit(Enemy enemy) => Visit((dynamic)enemy);

        public void Visit(Elf elf) => Score += 20;

        public void Visit(Ork ork) => Score += 10;

        public void Visit(Robot robot) => Score += 5;

        
    }
}