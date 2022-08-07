using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _crosshairs;
    [SerializeField] private float _tutorialDelay = 2f;

    private float _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _tutorialDelay)
        {
            _crosshairs.gameObject.SetActive(true);
        }
    }

    public void SetTargetPosition(Vector3 position)
    {
        _crosshairs.position = _camera.WorldToScreenPoint(position);
    }

    public void Stop()
    {
        _crosshairs.gameObject.SetActive(false);
        enabled = false;
    }
}
