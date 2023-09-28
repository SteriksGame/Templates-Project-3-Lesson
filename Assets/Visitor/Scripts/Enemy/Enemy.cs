using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public event Action<Enemy> Spawn;
    public event Action<Enemy> Died;

    private bool _isDead = false;

    public bool IsDead => _isDead;
    
    // Какие то реализации и логика

    //public abstract void Accept(IEnemyVisitor visitor);

    public void MoveTo(Vector3 position) => transform.position = position;

    public void Kill()
    {
        _isDead = true;
        Died?.Invoke(this);
        Destroy(gameObject);
    }

    private void Start() => Spawn?.Invoke(this);
}