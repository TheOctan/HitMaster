public class FollowState : BaseState<EnemyState>
{
    public FollowState(BaseStateMachine<EnemyState> stateMachine,
        EnemyMovementContext movementContext,
        EnemyAnimationContext animationContext)
        : base(stateMachine, movementContext, animationContext)
    {
    }

    public override void EnterState()
    {
        AnimationContext.IsFollow = true;
        MovementContext.Start();
    }

    public override void UpdateState()
    {
        AnimationContext.WalkingSpeed = MovementContext.CurrentSpeed;
    }

    public override void ExitState()
    {
        AnimationContext.IsFollow = false;
        MovementContext.Stop();
    }
}