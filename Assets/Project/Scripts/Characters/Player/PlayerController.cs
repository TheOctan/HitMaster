using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[SelectionBase]
public class PlayerController : MonoBehaviour, IPlayer
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _knifeHolder;

    [Header("Properties")]
    [SerializeField] private float _focusDistance = 3f;

    private IDropper _dropper;
    private InputMaster _inputMaster;

    private readonly List<Vector3> _points = new List<Vector3>();

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
        Gizmos.color = Color.red;
        foreach (Vector3 point in _points)
        {
            Vector3 startPosition = _camera.transform.position;

            Gizmos.DrawSphere(point, 0.1f);
            Gizmos.DrawRay(startPosition, (point - startPosition));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 startCameraPosition = _camera.transform.position;
        Vector3 direction = transform.forward * _focusDistance;
        Gizmos.DrawRay(startCameraPosition, direction);
        
        Gizmos.color = Color.green;
        Vector3 endPoint = startCameraPosition + direction;
        Vector3 startKnifePosition = _knifeHolder.position;
        Gizmos.DrawRay(startKnifePosition, endPoint - startKnifePosition);
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

    private void RaycastTo(Vector2 point)
    {
        Vector3 worldPoint = _camera.ScreenToWorldPoint(new Vector3(point.x, point.y, 10));
        _points.Add(worldPoint);
        //_dropper?.DropItemToDirection(ray);
    }

    private Ray CalculateDropDirection(Vector3 point)
    {
        return _camera.ScreenPointToRay(point);
    }
}