using System;
using UnityEngine;

namespace Project.Scripts.Enemy
{
    public class HealthController : MonoBehaviour, IHealthController
    {
        public event Action OnDie;
        public event Action<int> OnDamaged;

        [SerializeField, Min(1)] private int _maxHealth;
        [SerializeField, Min(0)] private int _startHealth;

        public int MaxHealth => _maxHealth;
        public int CurrentHealth { get; private set; }

        private void OnValidate()
        {
            if (_startHealth > _maxHealth)
            {
                _startHealth = _maxHealth;
            }
        }

        private void Awake()
        {
            CurrentHealth = _startHealth;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            OnDamaged?.Invoke(damage);

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                OnDie?.Invoke();
            }
        }
    }
}