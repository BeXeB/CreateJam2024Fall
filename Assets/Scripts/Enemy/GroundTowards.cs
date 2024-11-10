using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTowards : GroundBase
{
    [SerializeField] private float aggroRange = 5f;
    private bool hasHitPlayer;
    [SerializeField] private float aggroCooldown = 1f;
    private bool runningAway;
    
    
    private IEnumerator RunAway()
    {
        runningAway = true;
        yield return new WaitForSeconds(aggroCooldown);
        runningAway = false;
    }
    
    private void FixedUpdate()
    {
        if (hasHitPlayer)
        {
            rb.position = Vector2.MoveTowards(rb.position, new Vector2(target.position.x, rb.position.y), -speed * Time.fixedDeltaTime);
            hasHitPlayer = false;
            StartCoroutine(RunAway());
            return;
        }
        if (Vector2.Distance(transform.position, target.position) < aggroRange && !runningAway)
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
