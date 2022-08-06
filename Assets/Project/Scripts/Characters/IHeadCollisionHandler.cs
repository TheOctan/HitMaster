using System;
using UnityEngine;

public interface IHeadCollisionHandler
{
    event Action<Vector3> OnHeadShot;
    void HeadShot(Vector3 direction);
}