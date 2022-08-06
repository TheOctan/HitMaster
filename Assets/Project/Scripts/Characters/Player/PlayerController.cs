using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public struct Line
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    public Line(Vector3 startPoint, Vector3 endPoint)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
    }
}

[SelectionBase]
public class PlayerController : MonoBehaviour, IPlayer
{
    [SerializeField] private Camera _camera;

    [Header("Properties")]
    [SerializeField] private float _raycastDistance = 3f;
    [SerializeField] private LayerMask _layerMask;

    private readonly List<Line> _debugLines = new List<Line>();
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

    private void OnDrawGizmos()
    {
        foreach (Line line in _debugLines)
        {
            Debug.DrawLine(line.startPoint, line.endPoint, Color.red);
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Vector3 position = _camera.transform.position;
        Vector3 direction = transform.forward;
        Gizmos.DrawRay(position, direction * _raycastDistance);
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
        Ray ray = _camera.ScreenPointToRay(point);

        Vector3 raycastPoint = 
            Physics.Raycast(ray, out RaycastHit hit, _raycastDistance, _layerMask)
                ? hit.point
                : ray.origin + ray.direction * _raycastDistance;

        Vector3 position = _camera.transform.position;
        _debugLines.Add(new Line(position, raycastPoint));
        _dropper?.DropItemTo(raycastPoint);
    }
}