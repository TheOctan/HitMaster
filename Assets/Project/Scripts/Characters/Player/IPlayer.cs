using System;

public interface IPlayer
{
    event Action OnDie;
    void Kill();
}