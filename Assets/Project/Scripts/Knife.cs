using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Knife : MonoBehaviour, IPoolable<Knife>
{
    [SerializeField, Min(0.1f)] private float _movementSpeed = 1f;
    [SerializeField, Min(0.1f)] private float _rotationSpeed = 2f;

    private Rigidbody _rigidbody;
    private Action<Knife> _returnToPool;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        ReturnToPool();
    }

    private void Update()
    {
        UpdateMovement();
        UpdateRotation();
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public void StopMove()
    {
        enabled = false;
    }

    public void StartMove()
    {
        enabled = true;
    }

    public void ReturnToPool()
    {
        _returnToPool?.Invoke(this);
    }

    void IPoolable<Knife>.Initialize(Action<Knife> callback)
    {
        _returnToPool = callback;
    }

    private void UpdateMovement()
    {
        Vector3 velocity = _direction * _movementSpeed;
        Vector3 movement = velocity * Time.deltaTime;

        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void UpdateRotation()
    {
        Quaternion targetRotation = Quaternion.LookRotation(_direction);
        float turnStep = _rotationSpeed * Time.deltaTime;

        Quaternion rotation = Quaternion.Slerp(_rigidbody.rotation, targetRotation, turnStep);
        _rigidbody.MoveRotation(rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHeadCollisionHandler headCollisionHandler))
        {
            headCollisionHandler.HeadShot();
        }
        else if (other.TryGetComponent(out IHealthController healthController))
        {
            healthController.TakeDamage(1);
        }
    }
}