using System;
using UnityEngine;

public class HealthController : MonoBehaviour, IHealthController
{
    public event Action<Vector3> OnDie;
    public event Action<int> OnDamaged;

    [SerializeField] private HeadCollisionHandler _headCollisionHandler;
    [SerializeField] private ParticleSystem _hitEffect;

    [Header("Properties")]
    [SerializeField, Min(1)] private int _maxHealth = 2;
    [SerializeField, Min(0)] private int _startHealth = 2;

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
        _headCollisionHandler.OnHeadShot += OnHeadShotHandler;
    }

    private void OnHeadShotHandler(Vector3 direction)
    {
        TakeDamage(direction, _maxHealth);
    }

    public void TakeDamage(Vector3 direction,  int damage)
    {
        CurrentHealth -= damage;
        OnDamaged?.Invoke(damage);

        HitEffect(direction);

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            OnDie?.Invoke(direction);
        }
    }

    private void HitEffect(Vector3 direction)
    {
        _hitEffect.transform.rotation = Quaternion.FromToRotation(Vector3.forward, direction);
        _hitEffect.Play();
    }
}