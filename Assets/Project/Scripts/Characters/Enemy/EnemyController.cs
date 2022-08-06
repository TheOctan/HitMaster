using UnityEngine;
using UnityEngine.AI;

[SelectionBase]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private RagdollControl _ragdollControl;

    private EnemyStateMachine _stateMachine;
    private EnemyMovementContext _movementContext;
    private EnemyAnimationContext _animationContext;

    private void Awake()
    {
        _movementContext = new EnemyMovementContext(_agent);
        _animationContext = new EnemyAnimationContext(_animator, _ragdollControl);
        _stateMachine = new EnemyStateMachine(_movementContext, _animationContext);
        _stateMachine.SwitchState(EnemyState.Idle);

        _agent.enabled = false;

        if (TryGetComponent(out IHealthController healthController))
        {
            healthController.OnDie += OnDieHandler;
        }
    }

    private void OnDieHandler(Vector3 pushDirection)
    {
        _animationContext.PushDirection = pushDirection;
        _stateMachine.SwitchState(EnemyState.Die);
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
        Debug.Log(nameof(StartFollowing));
        _stateMachine.SwitchState(EnemyState.Follow);
    }

    public void StopFollowing()
    {
        _stateMachine.SwitchState(EnemyState.Idle);
    }
}