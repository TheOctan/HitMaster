using System.Collections.Generic;

public enum EnemyState
{
    None = -1,
    Idle,
    Follow,
    Attack,
    Die
}

public class EnemyStateFactory : BaseStateFactory<EnemyState>
{
    private readonly EnemyMovementContext _movementContext;
    private readonly EnemyAnimationContext _animationContext;

    public EnemyStateFactory(BaseStateMachine<EnemyState> baseStateMachine,
        EnemyMovementContext movementContext,
        EnemyAnimationContext animationContext)
        : base(baseStateMachine)
    {
        _animationContext = animationContext;
        _movementContext = movementContext;
    }

    protected override void RegisterStates(Dictionary<EnemyState, BaseState<EnemyState>> states,
        BaseStateMachine<EnemyState> stateMachine)
    {
        states.Add(EnemyState.Idle, new IdleState(stateMachine, _movementContext, _animationContext));
        states.Add(EnemyState.Follow, new FollowState(stateMachine, _movementContext, _animationContext));
        states.Add(EnemyState.Attack, new AttackState(stateMachine, _movementContext, _animationContext));
        states.Add(EnemyState.Die, new DieState(stateMachine, _movementContext, _animationContext));
    }
}