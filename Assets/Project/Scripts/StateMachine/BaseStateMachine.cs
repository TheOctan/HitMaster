using System;
using System.Collections.Generic;

public abstract class BaseStateMachine<T> where T : Enum
{
    protected abstract BaseStateFactory<T> StateFactory { get; }
    private BaseState<T> _currentState;
    private T _currentStateType;

    public void SwitchState(T state)
    {
        if (EqualityComparer<T>.Default.Equals(_currentStateType, state))
        {
            return;
        }

        _currentState?.ExitState();
        BaseState<T> newState = StateFactory.GetState(state);
        newState.EnterState();

        _currentState = newState;
        _currentStateType = state;
    }

    public void Update()
    {
        _currentState?.UpdateState();
    }
}