using System;

public interface IHealthController
{
    event Action OnDie;
    event Action<int> OnDamaged;
    int MaxHealth { get; }
    int CurrentHealth { get; }
    void TakeDamage(int damage);
}