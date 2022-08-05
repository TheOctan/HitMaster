using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MovmentController : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        if (!ReferenceEquals(_target, null))
        {
            //_agent.SetDestination(_target.position);
        }
    }
}