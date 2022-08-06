using System;
using UnityEngine;

public class HeadCollisionHandler : MonoBehaviour, IHeadCollisionHandler
{
    public event Action<Vector3> OnHeadShot;
    public void HeadShot(Vector3 direction)
    {
        OnHeadShot?.Invoke(direction);
    }
}
