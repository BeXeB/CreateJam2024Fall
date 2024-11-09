using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTowards : GroundBase
{
    [SerializeField] private float aggroRange = 5f;
    private bool hasHitPlayer;
    [SerializeField] private float aggroCooldown = 1f;
    private float aggroTimer;
    
    private void Update()
    {
        if (aggroTimer > 0)
        {
            aggroTimer -= Time.deltaTime;
        }
    }
    
    private void FixedUpdate()
    {
        if (hasHitPlayer)
        {
            rb.position = Vector2.MoveTowards(rb.position, new Vector2(target.position.x, rb.position.y), -speed * Time.fixedDeltaTime);
            if (!(Vector2.Distance(transform.position, target.position) > aggroRange)) return;
            hasHitPlayer = false;
            aggroTimer = aggroCooldown;
            return;
        }
        if (Vector2.Distance(transform.position, target.position) < aggroRange)
        {
            rb.position = Vector2.MoveTowards(rb.position, new Vector2(target.position.x, rb.position.y), speed * Time.fixedDeltaTime);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hasHitPlayer = true;
        }
    }
}
