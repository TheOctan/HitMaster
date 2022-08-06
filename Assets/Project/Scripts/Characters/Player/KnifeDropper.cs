using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class KnifeDropper : MonoBehaviour, IDropper
{
    [SerializeField] private Knife _knifePrefab;
    [SerializeField] private Transform _knifeHolder;

    // private ObjectPool<Knife> _objectPool;
    private Line _debugLine;

    private void Awake()
    {
        // _objectPool = new ObjectPool<Knife>(_knifePrefab, 15);
    }

    private void Update()
    {
        Debug.DrawLine(_debugLine.startPoint, _debugLine.endPoint, Color.green);
    }

    public void DropItemTo(Vector3 point)
    {
        Vector3 position = _knifeHolder.position;
        _debugLine = new Line(position, point);

        // TODO: optimize by object pool
        Knife knife =
            Object.Instantiate(_knifePrefab, _knifeHolder.position, _knifeHolder.rotation);
        //_objectPool.Pull(_knifeHolder.position, _knifeHolder.rotation);

        Vector3 direction = (point - position).normalized;
        knife.SetDirection(direction);
        knife.StartMove();
    }
}