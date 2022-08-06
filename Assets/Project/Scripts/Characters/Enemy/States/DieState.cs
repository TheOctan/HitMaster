public class DieState : BaseState<EnemyState>
{
    public DieState(BaseStateMachine<EnemyState> stateMachine,
        EnemyMovementContext movementContext,
        EnemyAnimationContext animationContext)
        : base(stateMachine, movementContext, animationContext)
    {
    }

    public override void EnterState()
    {
        AnimationContext.PushToBody();
        MovementContext.Stop();
    }

    public override void UpdateState()
    {
    }

    public override void ExitState()
    {
    }
}