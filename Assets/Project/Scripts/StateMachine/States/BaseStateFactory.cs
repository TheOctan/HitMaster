using System;
using System.Collections.Generic;

public abstract class BaseStateFactory<T> where T : Enum
{
    private readonly Dictionary<T, BaseState<T>> _states =
        new Dictionary<T, BaseState<T>>();

    private readonly BaseStateMachine<T> _baseStateMachine;

    protected BaseStateFactory(BaseStateMachine<T> baseStateMachine)
    {
        _baseStateMachine = baseStateMachine;
    }

    public void RegisterStates()
    {
        RegisterStates(_states);
    }

    protected abstract void RegisterStates(Dictionary<T, BaseState<T>> states);

    public BaseState<T> GetState(T state)
    {
        return _states.ContainsKey(state)
            ? _states[state]
            : null;
    }
}