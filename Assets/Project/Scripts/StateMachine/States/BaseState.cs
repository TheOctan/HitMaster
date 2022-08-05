using System;

public abstract class BaseState<T> where T : Enum
{
    protected EnemyMovementContext MovementContext { get; }
    protected EnemyAnimationContext AnimationContext { get; }
    private readonly BaseStateMachine<T> _stateMachine;

    protected BaseState(BaseStateMachine<T> stateMachine,
        EnemyMovementContext movementContext,
        EnemyAnimationContext animationContext)
    {
        _stateMachine = stateMachine;
        MovementContext = movementContext;
        AnimationContext = animationContext;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();

    protected void SwitchState(T newState)
    {
        _stateMachine.SwitchState(newState);
    }
}