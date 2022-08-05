using System;
using UnityEngine;

public class HeadCollisionHandler : MonoBehaviour, IHeadCollisionHandler
{
    public event Action OnHeadShot;
    public void HeadShot()
    {
        OnHeadShot?.Invoke();
    }
}
