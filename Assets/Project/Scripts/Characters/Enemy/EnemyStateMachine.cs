public class EnemyStateMachine : BaseStateMachine<EnemyState>
{
    private readonly EnemyStateFactory _enemyStateFactory;
    protected override BaseStateFactory<EnemyState> StateFactory => _enemyStateFactory;
    protected override EnemyState InitialStateType => EnemyState.None;

    public EnemyStateMachine(EnemyMovementContext movementContext,
        EnemyAnimationContext animationContext)
    {
        _enemyStateFactory = new EnemyStateFactory(this, movementContext, animationContext);
        _enemyStateFactory.RegisterStates();
    }
}