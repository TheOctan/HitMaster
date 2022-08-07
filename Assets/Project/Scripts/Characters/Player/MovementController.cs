using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        if (_target != null)
        {
            _agent.SetDestination(_target.position);
        }
    }

    public void StartMovement()
    {
        _agent.enabled = true;
    }

    public void StopMovement()
    {
        _agent.enabled = false;
    }
}