using System;
using UnityEngine;

public class HeadCollisionHandler : MonoBehaviour, IHeadCollisionHandler
{
    [SerializeField] private Collider _collider;

    public event Action<Vector3> OnHeadShot;
    public void HeadShot(Vector3 direction)
    {
        _collider.enabled = false;
        OnHeadShot?.Invoke(direction);
    }
}
