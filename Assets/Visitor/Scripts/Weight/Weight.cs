using System;
using UnityEngine;

public class Weight : IDisposable
{
    public IEnemySpawnNotifier _enemySpawnNotifier;
    public IEnemyDeathNotifier _enemyDeathNotifier;

    private EnemyWeightVisitor _enemyWeightVisitor;

    private const int MAX_WEIGHT_VALUE = 100;

    public Weight(IEnemySpawnNotifier enemySpawnNotifier, IEnemyDeathNotifier enemyDeathNotifier)
    {
        _enemySpawnNotifier = enemySpawnNotifier;
        _enemySpawnNotifier.SpawnNotified += OnEnemyChangeStatus;

        _enemyDeathNotifier = enemyDeathNotifier;
        _enemyDeathNotifier.DeadNotified += OnEnemyChangeStatus;

        _enemyWeightVisitor = new EnemyWeightVisitor();
    }

    public int Value => _enemyWeightVisitor.Value;

    public void Dispose()
    {
        _enemySpawnNotifier.SpawnNotified -= OnEnemyChangeStatus;

        _enemyDeathNotifier.DeadNotified -= OnEnemyChangeStatus;
    }

    public void OnEnemyChangeStatus(Enemy enemy)
    {
        _enemyWeightVisitor.Visit(enemy);
        Debug.Log($"Вес героев: {Value}");
    }

    public bool IsMaxWeight() => Value > MAX_WEIGHT_VALUE;

    private class EnemyWeightVisitor : IEnemyVisitor
    {
        private const int ELF_WEIGHT = 5;
        private const int ORK_WEIGHT = 10;
        private const int ROBOT_WEIGH = 15;

        public int Value { get; private set; }

        public void Visit(Enemy enemy) => Visit((dynamic)enemy);

        public void Visit(Elf elf) => Value = elf.IsDead ? Value - ELF_WEIGHT : Value + ELF_WEIGHT;

        public void Visit(Ork ork) => Value = ork.IsDead ? Value - ORK_WEIGHT : Value + ORK_WEIGHT;

        public void Visit(Robot robot) => Value = robot.IsDead ? Value - ROBOT_WEIGH : Value + ROBOT_WEIGH;
    }
}

