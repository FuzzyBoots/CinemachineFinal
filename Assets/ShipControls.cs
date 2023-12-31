using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    [SerializeField] private float _rotSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _currentSpeed;
    private float _vertical;
    private float _horizontal;
    [SerializeField] private float _maxRotate;
    [SerializeField] private GameObject _shipModel;
    [SerializeField] private float _maxSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _currentSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ShipMovement();
    }

    private void ShipMovement()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.T))
        {
            _currentSpeed++;
            if (_currentSpeed > _maxSpeed)
            {
                _currentSpeed = _maxSpeed;
            }
        }//increase speed

        if (Input.GetKeyDown(KeyCode.G))
        {
            _currentSpeed--;
            if (_currentSpeed < 1)
            {
                _currentSpeed = 1;
            }
        }//decrease speed

        Vector3 rotateH = new Vector3(0, _horizontal, 0);
        _shipModel.transform.Rotate(rotateH * _rotSpeed * Time.deltaTime);

        Vector3 rotateV = new Vector3(_vertical, 0, 0);
        _shipModel.transform.Rotate(rotateV * _rotSpeed * Time.deltaTime);

        _shipModel.transform.Rotate(new Vector3(0, 0, -_horizontal * 0.2f), Space.Self);

        _shipModel.transform.position += transform.forward * _currentSpeed * Time.deltaTime;
    }
}