using UnityEngine;
using UnityEngine.InputSystem;

[SelectionBase]
public class PlayerController : MonoBehaviour, IPlayer
{
    private IDropper _dropper;
    private InputMaster _inputMaster;
    private Camera _camera;

    private void Awake()
    {
        _dropper = GetComponent<IDropper>();
        if (ReferenceEquals(_dropper, null))
        {
            Debug.LogError("Player player must have any Dropper component");
        }
        _inputMaster = new InputMaster();
        _camera = Camera.main;
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

    private void OnTouchPressed(InputAction.CallbackContext context)
    {
        var touchPosition = _inputMaster.Player.TouchPosition.ReadValue<Vector2>();
        if (touchPosition == Vector2.zero)
        {
            return;
        }

        Vector3 direction = CalculateDropDirection(touchPosition);
        _dropper?.DropItemToDirection(direction);
    }

    private Vector3 CalculateDropDirection(Vector3 point)
    {
        Ray ray = _camera.ScreenPointToRay(point);
        return ray.direction;
    }
}