using System;

public interface IHeadCollisionHandler
{
    event Action OnHeadShot;
    void HeadShot();
}