using System;

public interface IPlayerTriggerListener
{
    event Action OnPlayerEnter;
    event Action OnPlayerExit;
}