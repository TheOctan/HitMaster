using System;
using UnityEngine;

public class KnifeDropper : MonoBehaviour, IDropper
{
    [SerializeField] private Knife _knifePrefab;
    [SerializeField] private Transform _knifeHolder;

    private ObjectPool<Knife> _objectPool;

    private void Awake()
    {
        _objectPool = new ObjectPool<Knife>(_knifePrefab, 15);
    }

    public void DropItemToDirection(Vector3 direction)
    {
        Knife knife = _objectPool.Pull();
    }
}