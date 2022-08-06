using System;
using UnityEngine;

public class PlayerTriggerListener : MonoBehaviour, IPlayerTriggerListener
{
    public event Action OnPlayerEnter;
    public event Action OnPlayerExit;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController _))
        {
            OnPlayerEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IPlayer _))
        {
            OnPlayerExit?.Invoke();
        }
    }
}