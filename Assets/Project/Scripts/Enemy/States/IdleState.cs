public class IdleState : BaseState<EnemyState>
{
    public IdleState(BaseStateMachine<EnemyState> stateMachine,
        PlayerMovementContext movementContext,
        EnemyAnimationContext animationContext)
        : base(stateMachine/*, movementContext, animationContext*/)
    {
    }

    public override void EnterState()
    {
    }

    public override void UpdateState()
    {
        // if (MovementContext.IsAttack)
        // {
        //     SwitchState(PlayerState.Attack);
        // }
        // else if (MovementContext.IsMoved)
        // {
        //     SwitchState(PlayerState.Walk);
        // }
    }

    public override void ExitState()
    {
    }
}