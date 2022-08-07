using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _rigidbodies;

    [SerializeField] private Rigidbody _head;
    [SerializeField] private Rigidbody _body;

    [Header("Properties")]
    [SerializeField] private float _pushImpulse = 500f;

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

    public void PushToHead(Vector3 direction)
    {
        SwitchToPhysical();
        _head.AddForce(direction * _pushImpulse, ForceMode.Impulse);
    }

    public void PushToBody(Vector3 direction)
    {
        SwitchToPhysical();
        _body.AddForce(direction * _pushImpulse, ForceMode.Impulse);
    }
}