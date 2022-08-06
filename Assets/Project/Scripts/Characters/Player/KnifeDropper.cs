using System.Collections.Generic;
using UnityEngine;

public class KnifeDropper : MonoBehaviour, IDropper
{
    [SerializeField] private Knife _knifePrefab;
    [SerializeField] private Transform _knifeHolder;

    // private ObjectPool<Knife> _objectPool;
    private readonly List<Line> _lines = new List<Line>();

    private void Awake()
    {
        // _objectPool = new ObjectPool<Knife>(_knifePrefab, 15);
    }

    public void DropItemTo(Vector3 point)
    {
        Vector3 position = _knifeHolder.position;
        _lines.Add(new Line(position, point));

        // TODO: optimize by object pool
        Knife knife =
            Object.Instantiate(_knifePrefab, _knifeHolder.position, _knifeHolder.rotation);
        //_objectPool.Pull(_knifeHolder.position, _knifeHolder.rotation);

        Vector3 direction = (point - position).normalized;
        knife.SetDirection(direction);
        knife.StartMove();
    }

    private void OnDrawGizmos()
    {
        foreach (Line line in _lines)
        {
            Debug.DrawLine(line.startPoint, line.endPoint, Color.green);
        }
    }
}