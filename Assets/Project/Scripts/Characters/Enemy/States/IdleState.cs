public class IdleState : BaseState<EnemyState>
{
    public IdleState(BaseStateMachine<EnemyState> stateMachine,
        EnemyMovementContext movementContext,
        EnemyAnimationContext animationContext)
        : base(stateMachine, movementContext, animationContext)
    {
    }

    public override void EnterState()
    {
    }

    public override void UpdateState()
    {
    }

    public override void ExitState()
    {
    }
}