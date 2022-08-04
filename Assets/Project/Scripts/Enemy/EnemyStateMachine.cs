public class EnemyStateMachine : BaseStateMachine<EnemyState>
{
    private readonly EnemyStateFactory _enemyStateFactory;

    protected override BaseStateFactory<EnemyState> StateFactory => _enemyStateFactory;

    public EnemyStateMachine(BaseStateFactory<EnemyState> stateFactory,
        PlayerMovementContext movementContext,
        EnemyAnimationContext animationContext)
    {
        _enemyStateFactory = new EnemyStateFactory(this);
    }
}