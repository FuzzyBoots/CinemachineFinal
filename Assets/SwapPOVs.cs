using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPOVs : MonoBehaviour
{
    [SerializeField] GameObject[] _POVs;
    [SerializeField] int _POVIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (_POVs.Length < 1)
        {
            Debug.LogError("No POVs defined for POV Swap");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SwapPOV();
        }
    }

    private void SwapPOV()
    {
        int nextIndex = (_POVIndex + 1) % _POVs.Length;
        _POVs[_POVIndex].SetActive(false);
        _POVs[nextIndex].SetActive(true);
        _POVIndex = nextIndex;
    }
}
