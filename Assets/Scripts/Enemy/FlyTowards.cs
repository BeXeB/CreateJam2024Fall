using UnityEngine;

public class FlyTowards : FlyBase
{
    private bool hasHitPlayer;
    [SerializeField] private float aggroCooldown = 1f;
    [SerializeField] private float aggroTimer;

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
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.fixedDeltaTime);
            if (!(Vector2.Distance(transform.position, target.position) > aggroRange)) return;
            hasHitPlayer = false;
            aggroTimer = aggroCooldown;
            return;
        }
        if (aggroTimer > 0) return;
        if (!target) return;
        if (Vector2.Distance(transform.position, target.position) > aggroRange) return;
        if (Vector2.Distance(transform.position, target.position) > distanceToStop)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
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
