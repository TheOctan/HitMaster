using System;
using UnityEngine;
using UnityEngine.InputSystem;

[SelectionBase]
public class PlayerController : MonoBehaviour, IPlayer
{
    public event Action OnFinished;
    public event Action OnDie;
    public event Action OnShoot;

    [SerializeField] private Camera _camera;
    [SerializeField] private MovementController _movementController;

    [Header("Properties")]
    [SerializeField] private float _raycastDistance = 3f;
    [SerializeField] private LayerMask _layerMask;

    private Line _debugLine;
    private InputMaster _inputMaster;
    private IDropper _dropper;

    private void Awake()
    {
        _dropper = GetComponent<IDropper>();
        if (ReferenceEquals(_dropper, null))
        {
            Debug.LogError("Player player must have any Dropper component");
        }
        _inputMaster = new InputMaster();
    }

    private void OnEnable()
    {
        _inputMaster.Enable();
        _inputMaster.Player.TouchPress.started += OnTouchPressed;
    }

    private void OnDisable()
    {
        _inputMaster.Disable();
        _inputMaster.Player.TouchPress.started -= OnTouchPressed;
    }

    private void Update()
    {
        Debug.DrawLine(_debugLine.startPoint, _debugLine.endPoint, Color.red);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Finish _))
        {
            OnFinished?.Invoke();
            enabled = false;
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Vector3 position = _camera.transform.position;
        Vector3 direction = transform.forward;
        Gizmos.DrawRay(position, direction * _raycastDistance);
    }

    public void Kill()
    {
        _movementController.StopMovement();
        OnDie?.Invoke();
        enabled = false;
    }

    private void OnTouchPressed(InputAction.CallbackContext context)
    {
        var touchPosition = _inputMaster.Player.TouchPosition.ReadValue<Vector2>();
        if (touchPosition == Vector2.zero)
        {
            return;
        }

        RaycastTo(touchPosition);
    }

    private void RaycastTo(Vector3 point)
    {
        OnShoot?.Invoke();
        Ray ray = _camera.ScreenPointToRay(point);

        Vector3 raycastPoint = 
            Physics.Raycast(ray, out RaycastHit hit, _raycastDistance, _layerMask)
                ? hit.point
                : ray.origin + ray.direction * _raycastDistance;

        Vector3 position = _camera.transform.position;
        _debugLine = new Line(position, raycastPoint);
        _dropper?.DropItemTo(raycastPoint);
    }
}