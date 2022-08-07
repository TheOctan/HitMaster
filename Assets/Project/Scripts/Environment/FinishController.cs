using System;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    public event Action OnPlayerFinished; 

    private void OnTriggerEnter(Collider other)
    {
        if (TryGetComponent(out IPlayer _))
        {
            OnPlayerFinished?.Invoke();
        }
    }
}