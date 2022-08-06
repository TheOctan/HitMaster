using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementContext : IDisposable
{
    private readonly NavMeshAgent _agent;
    private readonly float _findTargetRate;
    private readonly Transform _transform;
    private Transform _target;
    private bool _isFollowing;

    private readonly float _attackDistance;
    private readonly float _collisionRadius;
    private float _targetCollisionRadius;

    private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

    private bool HasTarget => _target != null;
    public float CurrentSpeed => _agent.velocity.magnitude;

    public EnemyMovementContext(Transform transform, NavMeshAgent agent, float attackDistance, float findTargetRate)
    {
        _attackDistance = attackDistance;
        _findTargetRate = findTargetRate;
        _transform = transform;
        _agent = agent;

        _collisionRadius = transform.GetComponent<CapsuleCollider>().radius;
    }

    public void SetFollowTarget(Transform target)
    {
        _target = target;
        _targetCollisionRadius = _target.GetComponent<CapsuleCollider>().radius;
    }

    public void Start()
    {
        _agent.enabled = true;
        _isFollowing = true;

        CancellationToken token = _cancellationTokenSource.Token;
        UpdateTargetAsync(token);
    }

    public void Stop()
    {
        _agent.enabled = false;
        _isFollowing = false;
        _cancellationTokenSource.Cancel();
    }

    private async void UpdateTargetAsync(CancellationToken token)
    {
        while (HasTarget && _isFollowing)
        {
            await Task.Delay((int)(1000 * _findTargetRate));
            if (token.IsCancellationRequested)
            {
                return;
            }

            Vector3 direction = (_target.position - _transform.position).normalized;
            float distance = _collisionRadius + _targetCollisionRadius + _attackDistance;
            Vector3 targetPosition = _target.position - direction * distance;
            _agent.SetDestination(targetPosition);
        }
    }

    public void Dispose()
    {
        _cancellationTokenSource.Cancel();
        _cancellationTokenSource.Dispose();
    }
}