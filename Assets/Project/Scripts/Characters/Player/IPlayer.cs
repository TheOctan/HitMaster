using System;

public interface IPlayer
{
    event Action OnDie;
    event Action OnShoot;
    void Kill();
}