using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Rigidbody _rigidbody;

    [SerializeField] private Transform _camera;

    [SerializeField] private float powerUpDuration;

    private Coroutine _powerUpCoroutine;
    
    //Action
    public Action OnPowerUpStart;
    public Action OnPowerUpStop;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Start()

    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 horizontalDirection = horizontal * _camera.right;
        Vector3 verticalDirection = vertical * _camera.forward;

        verticalDirection.y = 0;
        horizontalDirection.y = 0;
        
        Vector3 movementDirection = horizontalDirection + verticalDirection;
        
        _rigidbody.velocity = movementDirection * (speed * Time.fixedDeltaTime);
    }

    public void PickPowerUp()
    {
        if (_powerUpCoroutine != null)
        {
            StopCoroutine(_powerUpCoroutine);
        }

        _powerUpCoroutine = StartCoroutine(StartPowerUp());
    }

    IEnumerator StartPowerUp()
    {
        if (OnPowerUpStart != null)
        {
            OnPowerUpStart();
        }
        
        yield return new WaitForSeconds(powerUpDuration);

        if (OnPowerUpStop != null)
        {
            OnPowerUpStop();
        }
    }
}
