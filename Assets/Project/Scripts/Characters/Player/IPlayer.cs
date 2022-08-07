using System;

public interface IPlayer
{
    event Action OnFinished;
    event Action OnDie;
    event Action OnShoot;
    void Kill();
}