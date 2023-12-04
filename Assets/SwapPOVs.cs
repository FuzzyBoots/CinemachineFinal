using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPOVs : MonoBehaviour
{
    [SerializeField] GameObject _externalCamera;
    [SerializeField] GameObject _internalCamera;
    [SerializeField] bool _inInternal = false;
    
    [SerializeField] GameObject _cinematicCamera;
    private float _cinematicTime;
    [SerializeField] private float _cinematicDelay = 5f;
    private Vector3 _priorMousePosition;
    [SerializeField]  private float _mouseMoveThreshold = 1f;

    // Start is called before the first frame update
    void Start()
    {
        if (_cinematicCamera == null)
        {
            Debug.LogError("No Cinematic camera set");
        }

        if (_internalCamera == null)
        {
            Debug.LogError("No internal camera found");
        }

        if (_externalCamera == null)
        {
            Debug.LogError("No external camera found");
        }

        _internalCamera.SetActive(false);
        _externalCamera.SetActive(true);
        _inInternal = false;

        _cinematicTime = Time.time + _cinematicDelay;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseDistance = Vector3.Distance(Input.mousePosition, _priorMousePosition);
        if (Input.anyKey || mouseDistance > _mouseMoveThreshold)
        {
            _cinematicTime = Time.time + _cinematicDelay;
            _cinematicCamera.SetActive(false);
        } else if (_cinematicTime < Time.time)
        {
            SetExternal();
            _cinematicCamera.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SwapPOV();
        }

        _priorMousePosition = Input.mousePosition;
    }

    private void SwapPOV()
    {
        if (_inInternal)
        {
            _externalCamera.SetActive(true);
            _internalCamera.SetActive(false);
        } else
        {
            _externalCamera.SetActive(false);
            _internalCamera.SetActive(true);
        }
        _inInternal = !_inInternal;
    }

    private void SetExternal()
    {
        if (_inInternal)
        {
            SwapPOV();
        }
    }
}
