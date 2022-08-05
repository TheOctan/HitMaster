using UnityEngine;
using UnityEngine.AI;

[SelectionBase]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    
    private EnemyStateMachine _stateMachine;
    private EnemyMovementContext _movementContext;
    private EnemyAnimationContext _animationContext;

    private void Awake()
    {
        _movementContext = new EnemyMovementContext(_agent);
        _animationContext = new EnemyAnimationContext(_animator);
        _stateMachine = new EnemyStateMachine(_movementContext, _animationContext);
        _stateMachine.SwitchState(EnemyState.Idle);

        _agent = GetComponent<NavMeshAgent>();
        _agent.enabled = false;
    }

    private void Update()
    {
        _stateMachine.Update();
        _movementContext.Update();
    }

    public void SetFollowTarget(Transform target)
    {
        _movementContext.SetFollowTarget(target);
    }

    public void StartFollowing()
    {
        _stateMachine.SwitchState(EnemyState.Follow);
    }

    public void StopFollowing()
    {
        _stateMachine.SwitchState(EnemyState.Idle);
    }
}