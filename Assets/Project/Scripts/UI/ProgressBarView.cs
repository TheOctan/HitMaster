using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _progressText;
    [SerializeField] private Slider _slider;
    public int MaximumValue { get; set; }

    public void SetValue(int value)
    {
        UpdateProgressBar(value);
    }

    private void UpdateProgressBar(int value)
    {
        _progressText.text = $"{value}/{MaximumValue}";
        float percent = (float)value / MaximumValue;
        _slider.value = percent;
    }
}