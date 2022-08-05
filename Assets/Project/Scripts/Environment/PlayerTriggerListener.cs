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
            Debug.Log($"{nameof(PlayerTriggerListener)}.{nameof(OnTriggerEnter)}");
            OnPlayerEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerController _))
        {
            Debug.Log($"{nameof(PlayerTriggerListener)}.{nameof(OnTriggerExit)}");
            OnPlayerExit?.Invoke();
        }
    }
}