using System.Collections.Generic;

public enum EnemyState
{
    None = -1,
    Idle,
    Walk,
    Attack
}

public class EnemyStateFactory : BaseStateFactory<EnemyState>
{
    public EnemyStateFactory(BaseStateMachine<EnemyState> baseStateMachine/*,
        PlayerMovementContext movementContext,
        EnemyAnimationContext animationContext*/)
        : base(baseStateMachine)
    {
        
    }

    protected override void RegisterStates(Dictionary<EnemyState, BaseState<EnemyState>> states)
    {
        // states.Add(PlayerState.Idle, new IdleState(stateMachine, movementContext, animationContext));
        // states.Add(PlayerState.Walk, new WalkState(stateMachine, movementContext, animationContext));
        // states.Add(PlayerState.Attack, new AttackState(stateMachine, movementContext, animationContext));
    }
}