using System;

public abstract class BaseState<T> where T : Enum
{
    private readonly BaseStateMachine<T> _stateMachine;

    protected BaseState(BaseStateMachine<T> stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();

    protected void SwitchState(T newState)
    {
        _stateMachine.SwitchState(newState);
    }
}