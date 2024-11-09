using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HoldToCapture : MonoBehaviour
{
    [SerializeField] private float holdDuration = 1f;
    [SerializeField] private Image fillCircle;
    private CapturableEnemy capturableEnemy;

    private float holdTimer;
    private bool isHolding;

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
                capturableEnemy = null;
            }
        }
    }

    public void OnHold(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isHolding = true;
            if (!capturableEnemy) return;
            capturableEnemy.StartCapture();
            OnHoldComplete += capturableEnemy.EndCapture;
        }
        else if (context.canceled)
        {
            ResetHold();
        }
    }

    private void ResetHold()
    {
        isHolding = false;
        holdTimer = 0;
        fillCircle.fillAmount = 0;
        OnHoldComplete = null;
        capturableEnemy?.StopCapture();
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
