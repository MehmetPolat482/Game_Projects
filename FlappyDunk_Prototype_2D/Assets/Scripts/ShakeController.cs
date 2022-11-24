using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeController : MonoBehaviour
{
    public Transform _cam;
    private Vector3 _startPos;

    public float _shakePower;
    public float _shakeDuration;
    private float _initialDuration;
    public float _downAmount;
    public bool _isShake = false;

    void Start()
    {
        _cam = Camera.main.transform;
        _startPos = _cam.localPosition;
        _initialDuration = _shakeDuration;
    }

    public void ShakeSystem()
    {
        if (_isShake)
        {
            if (_shakeDuration > 0)
            {
                _cam.localPosition = _startPos + Random.insideUnitSphere * _shakePower;
                _shakeDuration -= _downAmount * Time.deltaTime;
            }
            else
            {
                _isShake = false;
                _cam.localPosition = _startPos;
                _shakeDuration = _initialDuration;
            }
        }
    }
}
