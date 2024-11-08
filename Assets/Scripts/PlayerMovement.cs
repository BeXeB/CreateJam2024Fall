using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float moveSpeed = 1.0f;
    private float horizontalMovement;

    [SerializeField] 
    private float jumpPower = 10f;
    [SerializeField] 
    private int maxJumps = 2;
    private int jumpsRemaining;


    [SerializeField] 
    private Transform groundCheckPosition;
    [SerializeField] 
    private Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    [SerializeField] 
    private LayerMask groundLayer;

    [SerializeField]
    private float baseGravity = 2f;
    [SerializeField]
    private float maxFallSpeed = 18f;
    [SerializeField]
    private float fallSpeedMultiplier = 2f;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(horizontalMovement * moveSpeed, rigidBody.velocity.y);
        GroundCheck();
        Gravity();
    }

    private void Gravity()
    {
        if (rigidBody.velocity.y < 0)
        {
            rigidBody.gravityScale = baseGravity * fallSpeedMultiplier;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, Mathf.Max(rigidBody.velocity.y, -maxFallSpeed));
        }
        else
        {
            rigidBody.gravityScale = baseGravity;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpsRemaining > 0)
        {
            if (context.performed)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpPower);
                jumpsRemaining--;
            }
            else if (context.canceled)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y * 0.5f);
                jumpsRemaining--;
            }
        }
    }

    public IEnumerator Stun(float stunDuration)
    {
        playerInput.DeactivateInput();
        yield return new WaitForSeconds(stunDuration);
        playerInput.ActivateInput();
    }

    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPosition.position, groundCheckSize, 0, groundLayer))
        {
            jumpsRemaining = maxJumps;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(groundCheckPosition.position, groundCheckSize);
    }
}
