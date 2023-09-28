using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyFactory", menuName = "Factory/EnemyFactory")]
public class EnemyFactory : ScriptableObject
{
    [SerializeField] private Elf _elf;
    [SerializeField] private Ork _ork;
    [SerializeField] private Robot _robot;

    public Enemy Get(EnemyTypes enemyTypes)
    {
        switch (enemyTypes)
        {
            case EnemyTypes.Elf:
                return Instantiate(_elf);

            case EnemyTypes.Ork:
                return Instantiate(_ork);

            case EnemyTypes.Robot:
                return Instantiate(_robot);

            default:
                throw new ArgumentException(nameof(enemyTypes));
        }
    }
}
