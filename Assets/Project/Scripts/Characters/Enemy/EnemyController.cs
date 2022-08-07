using System;
using UnityEngine;
using UnityEngine.AI;

[SelectionBase]
public class EnemyController : MonoBehaviour, IEnemy
{
    public event Action OnDie;

    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private RagdollController _ragdollController;
    [SerializeField] private AttackController _attackController;

    [Header("Properties")]
    [SerializeField] private float _findTargetRate = 0.25f;

    private EnemyStateMachine _stateMachine;
    private EnemyMovementContext _movementContext;
    private EnemyAnimationContext _animationContext;


    private void Awake()
    {
        _movementContext = new EnemyMovementContext(transform, _agent, _attackController.AttackDistance, _findTargetRate);
        _animationContext = new EnemyAnimationContext(_animator, _ragdollController);
        _stateMachine = new EnemyStateMachine(_movementContext, _animationContext);
        _stateMachine.SwitchState(EnemyState.Idle);

        _agent.enabled = false;

        if (TryGetComponent(out IHealthController healthController))
        {
            healthController.OnDie += OnDieHandler;
        }
    }

    private void OnDestroy()
    {
        _movementContext.Dispose();
    }

    private void OnDieHandler(Vector3 pushDirection)
    {
        OnDie?.Invoke();
        _animationContext.PushDirection = pushDirection;
        _attackController.enabled = false;
        _stateMachine.SwitchState(EnemyState.Die);
    }

    private void Update()
    {
        _stateMachine.Update();
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