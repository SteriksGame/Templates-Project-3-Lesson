using System;
using UnityEngine;

public class Weight : IDisposable
{
    public IEnemySpawnNotifier _enemySpawnNotifier;
    public IEnemyDeathNotifier _enemyDeathNotifier;

    private EnemyWeightVisitor _enemyWeightVisitor;

    public Weight(IEnemySpawnNotifier enemySpawnNotifier, IEnemyDeathNotifier enemyDeathNotifier)
    {
        _enemySpawnNotifier = enemySpawnNotifier;
        _enemySpawnNotifier.SpawnNotified += OnEnemyChangeStatus;

        _enemyDeathNotifier = enemyDeathNotifier;
        _enemyDeathNotifier.DeadNotified += OnEnemyChangeStatus;

        _enemyWeightVisitor = new EnemyWeightVisitor();
    }

    public int Volue => _enemyWeightVisitor.Volue;

    public void Dispose()
    {
        _enemySpawnNotifier.SpawnNotified -= OnEnemyChangeStatus;

        _enemyDeathNotifier.DeadNotified -= OnEnemyChangeStatus;
    }

    public void OnEnemyChangeStatus(Enemy enemy)
    {
        _enemyWeightVisitor.Visit(enemy);
        Debug.Log($"Вес героев: {Volue}");
    }

    private class EnemyWeightVisitor : IEnemyVisitor
    {
        private const int ELF_WEIGHT = 5;
        private const int ORK_WEIGHT = 10;
        private const int ROBOT_WEIGH = 15;

        public int Volue { get; private set; }

        public void Visit(Enemy enemy) => Visit((dynamic)enemy);

        public void Visit(Elf elf) => Volue = elf.IsDead ? Volue - ELF_WEIGHT : Volue + ELF_WEIGHT;

        public void Visit(Ork ork) => Volue = ork.IsDead ? Volue - ORK_WEIGHT : Volue + ORK_WEIGHT;

        public void Visit(Robot robot) => Volue = robot.IsDead ? Volue - ROBOT_WEIGH : Volue + ROBOT_WEIGH;
    }
}

