using System;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenView : MonoBehaviour
{
    public event Action OnNextLevelButtonClicked;

    [SerializeField] private Button _NextLevelButton;

    private void OnEnable()
    {
        _NextLevelButton.onClick.AddListener(OnNextLevelButtonClickedHandler);
    }

    private void OnDisable()
    {
        _NextLevelButton.onClick.RemoveListener(OnNextLevelButtonClickedHandler);
    }

    private void OnNextLevelButtonClickedHandler()
    {
        OnNextLevelButtonClicked?.Invoke();
    }
}