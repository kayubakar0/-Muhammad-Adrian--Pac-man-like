using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Rigidbody _rigidbody;

    [SerializeField] private Transform _camera;

    [SerializeField] private float powerUpDuration;

    private Coroutine _powerUpCoroutine;

    private bool _isPowerUpActive;

    [SerializeField] private Transform respawnPoint;
    [SerializeField] private int health;
    
    [SerializeField] private TMP_Text healthText;
    
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
        UpdateUI();
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

    private void UpdateUI()
    {
        healthText.text = "Health : " + health;
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
        _isPowerUpActive = true;
        if (OnPowerUpStart != null)
        {
            OnPowerUpStart();
        }
        
        yield return new WaitForSeconds(powerUpDuration);

        _isPowerUpActive = false;
        if (OnPowerUpStop != null)
        {
            OnPowerUpStop();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_isPowerUpActive)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy>().Dead();
            }
        }
    }

    public void Dead()
    {
        health -= 1;
        if (health > 0)
        {
            transform.position = respawnPoint.position;
        }
        else
        {
            health = 0;
            Debug.Log("Lose");
        }
        
        UpdateUI();
    }
}
