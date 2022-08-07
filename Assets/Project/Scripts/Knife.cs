using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Rigidbody))]
public class Knife : MonoBehaviour, IPoolable<Knife>
{
    [SerializeField, Min(0.1f)] private float _movementSpeed = 1f;
    [SerializeField, Min(0.1f)] private float _rotationSpeed = 2f;
    [SerializeField, Min(0.1f)] private float _disableDelay = 2f;

    private Action<Knife> _returnToPool;
    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private async void DisableByDelayAsync(CancellationToken token)
    {
        await Task.Delay((int)(1000 * _disableDelay));
        if (token.IsCancellationRequested)
        {
            Debug.Log($"Task {nameof(DisableByDelayAsync)} was canceled");
            return;
        }
        ReturnToPool();
    }

    private void OnDisable()
    {
        //_cancellationTokenSource?.Cancel();
        ReturnToPool();
    }

    private void OnDestroy()
    {
        _cancellationTokenSource.Cancel();
        _cancellationTokenSource.Dispose();
    }

    private void Update()
    {
        UpdateMovement();
        UpdateRotation();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHeadCollisionHandler headCollisionHandler))
        {
            headCollisionHandler.HeadShot(_direction);
            ReturnToPool();
        }
        else if (other.TryGetComponent(out IHealthController healthController))
        {
            healthController.TakeDamage(_direction,1);
            ReturnToPool();
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public void StopMove()
    {
        enabled = false;
        _direction = Vector3.zero;
    }

    public void StartMove()
    {
        enabled = true;
        CancellationToken cancellationToken = _cancellationTokenSource.Token;
        DisableByDelayAsync(cancellationToken);
    }

    public void ReturnToPool()
    {
        StopMove();
        _returnToPool?.Invoke(this);
        // TODO: temporary solution
        Destroy(gameObject);
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
        if (_direction == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(_direction);
        float turnStep = _rotationSpeed * Time.deltaTime;

        Quaternion rotation = Quaternion.Slerp(_rigidbody.rotation, targetRotation, turnStep);
        _rigidbody.MoveRotation(rotation);
    }
}