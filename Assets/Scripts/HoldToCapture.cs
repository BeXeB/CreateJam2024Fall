using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HoldToCapture : MonoBehaviour
{
    [SerializeField] private float holdDuration = 1f;
    [SerializeField] private Image fillCircle;
    private CapturableEnemy capturableEnemy;
    private CapturableEnemy beingCaptured;

    private float holdTimer;
    private bool isHolding;

    public static event Action OnHoldComplete;

    [SerializeField] private Animator animator;

    private void OnEnable()
    {
        PlayerMovement.OnStun += ResetHold;
    }

    private void OnDisable()
    {
        PlayerMovement.OnStun -= ResetHold;
    }

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
                beingCaptured = null;
            }
        }
    }

    public void OnHold(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetBool("onAttack", true);
            isHolding = true;
            if (!capturableEnemy) return;
            capturableEnemy.StartCapture();
            beingCaptured = capturableEnemy;
            OnHoldComplete += beingCaptured.EndCapture;
        }
        else if (context.canceled)
        {
            ResetHold();
        }
    }

    private void ResetHold()
    {
        animator.SetBool("onAttack", false);
        isHolding = false;
        holdTimer = 0;
        fillCircle.fillAmount = 0;
        OnHoldComplete = null;
        beingCaptured?.StopCapture();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (capturableEnemy)
            {
                capturableEnemy.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            }
            capturableEnemy = other.GetComponent<CapturableEnemy>();
            var tempColor = "FDF995";
            var m_Red = System.Convert.ToByte(tempColor.Substring(0, 2), 16);
            var m_Green = System.Convert.ToByte(tempColor.Substring(2, 2), 16);
            var m_Blue = System.Convert.ToByte(tempColor.Substring(4, 2), 16);

            // always requires the alpha parameter
            var m_NewColor = new UnityEngine.Color32(m_Red, m_Green, m_Blue, 255);
            capturableEnemy.gameObject.GetComponentInChildren<SpriteRenderer>().color = m_NewColor;
        }
    }
        
    private void OnTriggerExit2D(Collider2D other)
    {
        if (capturableEnemy)
        {
            capturableEnemy.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            capturableEnemy = null;
        }
        capturableEnemy = null;
    }
}
