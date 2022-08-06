using System;
using UnityEngine;

public interface IHealthController
{
    event Action<Vector3> OnDie;
    event Action<int> OnDamaged;
    int MaxHealth { get; }
    int CurrentHealth { get; }
    void TakeDamage(Vector3 direction, int damage);
}