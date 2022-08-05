using UnityEngine;
using UnityEngine.AI;

[SelectionBase]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _target;

    private bool _isFollowing;

    private bool HasTarget => _target != null;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.enabled = false;
    }

    private void Update()
    {
        if (HasTarget && _isFollowing)
        {
            _agent.SetDestination(_target.position);
        }
    }

    public void SetFollowTarget(Transform target)
    {
        _target = target;
    }

    public void StartFollowing()
    {
        Debug.Log($"{nameof(EnemyController)}.{nameof(StartFollowing)}");
        _agent.enabled = true;
        _isFollowing = true;
    }

    public void StopFollowing()
    {
        Debug.Log($"{nameof(EnemyController)}.{nameof(StopFollowing)}");
        _agent.enabled = false;
        _isFollowing = false;
    }
}