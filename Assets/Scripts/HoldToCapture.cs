using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HoldToCapture : MonoBehaviour
{
    [SerializeField] private float holdDuration = 1f;
    [SerializeField] private Image fillCircle;
    private CapturableEnemy capturableEnemy;

    private float holdTimer = 0;
    private bool isHolding = false;

    public static event Action OnHoldComplete;
    
    void Update()
    {
        if (isHolding)
        {
            holdTimer += Time.deltaTime;
            fillCircle.fillAmount = holdTimer / holdDuration;
            if (holdTimer >= holdDuration)
            {
                OnHoldComplete?.Invoke();
                ResetHold();
            }
        }
    }

    public void OnHold(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isHolding = true;
            if (capturableEnemy == null) return;
            capturableEnemy.StartCapture();
            OnHoldComplete += capturableEnemy.EndCapture;
        }
        else if (context.canceled)
        {
            ResetHold();
            if (capturableEnemy == null) return;
            OnHoldComplete -= capturableEnemy.EndCapture;
            capturableEnemy.StopCapture();
        }
    }

    private void ResetHold()
    {
        isHolding = false;
        holdTimer = 0;
        fillCircle.fillAmount = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            capturableEnemy = other.GetComponent<CapturableEnemy>();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        capturableEnemy = null;
    }
}
