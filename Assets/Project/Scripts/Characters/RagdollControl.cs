using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _rigidbodies;

    private void Awake()
    {
        foreach (Rigidbody rigidbodyComponent in _rigidbodies)
        {
            rigidbodyComponent.isKinematic = true;
        }
    }

    [ContextMenu("SwitchToPhysical")]
    public void SwitchToPhysical()
    {
        _animator.enabled = false;
        foreach (Rigidbody rigidbodyComponent in _rigidbodies)
        {
            rigidbodyComponent.isKinematic = false;
        }
    }
}