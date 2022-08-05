using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementContext
{
    private readonly NavMeshAgent _agent;
    private Transform _target;
    private bool _isFollowing;

    private bool HasTarget => _target != null;
    public float CurrentSpeed => _agent.velocity.magnitude;

    public EnemyMovementContext(NavMeshAgent agent)
    {
        _agent = agent;
    }

    public void SetFollowTarget(Transform target)
    {
        _target = target;
    }

    public void Update()
    {
        if (HasTarget && _isFollowing)
        {
            _agent.SetDestination(_target.position);
        }
    }

    public void Start()
    {
        _agent.enabled = true;
        _isFollowing = true;
    }

    public void Stop()
    {
        _agent.enabled = false;
        _isFollowing = false;
    }
}