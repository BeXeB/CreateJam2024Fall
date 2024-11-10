using System.Collections;
using UnityEngine;

public class FlyTowards : FlyBase
{
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
        if (isBeingCaptured)
        {
            transform.position = target.position - positionDiff;
            return;
        }
        if (hasHitPlayer)
        {
            agent.SetDestination(transform.position + (transform.position - target.position).normalized * aggroRange);
            hasHitPlayer = false;
            StartCoroutine(RunAway());
            return;
        }
        if (runningAway) return;
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
