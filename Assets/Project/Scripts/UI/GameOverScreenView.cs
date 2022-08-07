using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenView : MonoBehaviour
{
    public event Action OnRestartButtonClicked;

    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClickedHandler);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClickedHandler);
    }

    private void OnRestartButtonClickedHandler()
    {
        OnRestartButtonClicked?.Invoke();
    }
}