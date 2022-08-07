using System;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private float _attackDistance = 1f;

    public float AttackDistance => _attackDistance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IPlayer player))
        {
            player.Kill();
        }
    }
}