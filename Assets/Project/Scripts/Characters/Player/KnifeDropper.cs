using System;
using System.Collections.Generic;
using UnityEngine;

public class KnifeDropper : MonoBehaviour, IDropper
{
    [SerializeField] private Knife _knifePrefab;
    [SerializeField] private Transform _knifeHolder;

    private ObjectPool<Knife> _objectPool;
    private List<Ray> _rays = new List<Ray>();

    private void Awake()
    {
        _objectPool = new ObjectPool<Knife>(_knifePrefab, 15);
    }

    public void DropItemToDirection(Ray ray)
    {
        _rays.Add(ray);
        // Knife knife = _objectPool.Pull(_knifeHolder.position, _knifeHolder.rotation);
        // knife.SetDirection(direction);
        // knife.StartMove();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector3 position = _knifeHolder.position;
        
        foreach (Ray ray in _rays)
        {
            Vector3 delta = ray.origin - position;
            Vector3 direction = ray.direction + delta;
            Gizmos.DrawRay(position, direction * 10f);
        }
    }
}