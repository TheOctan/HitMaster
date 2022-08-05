using UnityEngine;
using UnityEngine.AI;

[SelectionBase]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _target;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
    }

    public void SetFollowTarget(Transform target)
    {
        _target = target;
    }

    public void StartFollowing()
    {
        
    }

    public void StopFollowing()
    {
        
    }
}