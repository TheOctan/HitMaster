public class WalkState : BaseState<EnemyState>
{
    public WalkState(BaseStateMachine<EnemyState> stateMachine,
        PlayerMovementContext movementContext,
        EnemyAnimationContext animationContext)
        : base(stateMachine/*, movementContext, animationContext*/)
    {
    }

    public override void EnterState()
    {
        // AnimationContext.IsWalk = true;
        // MovementContext.Start();
    }

    public override void UpdateState()
    {
        // AnimationContext.WalkingSpeed = MovementContext.CurrentSpeed;

        // if (MovementContext.IsAttack)
        // {
        //     SwitchState(PlayerState.Attack);
        // }
        // else if (!MovementContext.IsMoved)
        // {
        //     SwitchState(PlayerState.Idle);
        // }
    }

    public override void ExitState()
    {
        // AnimationContext.IsWalk = false;
        // MovementContext.Stop();
    }
}