using UnityEngine;

public class FlyAway : FlyBase
{
    [SerializeField] private float safeDistance = 10f;
    private void FixedUpdate()
    {
        if (isBeingCaptured)
        {
            transform.position = target.position - positionDiff;
            return;
        }
        if (!target) return;
        if (Vector2.Distance(transform.position, target.position) < distanceToStop)
        {
            agent.SetDestination(transform.position + (transform.position - target.position).normalized * distanceToStop);
        }
        else if (Vector2.Distance(transform.position, target.position) > safeDistance)
        {
            var ray = new Ray(transform.position, Vector3.down);
            var hit = Physics2D.Raycast(ray.origin, ray.direction, floatHeight, LayerMask.GetMask("Ground"));
            if (!hit.collider || hit.collider.gameObject.layer != LayerMask.NameToLayer("Ground"))
            {
                agent.SetDestination(transform.position + Vector3.down);
            }
        }
    }
}
