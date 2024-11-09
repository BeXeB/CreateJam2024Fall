using UnityEngine;

public class FlyTowards : FlyBase
{
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
        if (isBeingCaptured)
        {
            transform.position = target.position - positionDiff;
            return;
        }
        if (hasHitPlayer)
        {
            agent.SetDestination(transform.position + (transform.position - target.position).normalized * aggroRange);
            if (!(Vector2.Distance(transform.position, target.position) > aggroRange)) return;
            hasHitPlayer = false;
            aggroTimer = aggroCooldown;
            return;
        }
        if (aggroTimer > 0) return;
        if (!target) return;
        if (Vector2.Distance(transform.position, target.position) > aggroRange)
        {
            var ray = new Ray(transform.position, Vector3.down);
            var hit = Physics2D.Raycast(ray.origin, ray.direction, floatHeight, LayerMask.GetMask("Ground"));
            if (!hit.collider || hit.collider.gameObject.layer != LayerMask.NameToLayer("Ground"))
            {
                agent.SetDestination(transform.position + Vector3.down);
            }
            return;
        }
        if (Vector2.Distance(transform.position, target.position) > distanceToStop)
        {
            agent.SetDestination(target.position);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioMananger.instance.PlayAudioClip("Ghost");
            hasHitPlayer = true;
        }
    }
}
