using UnityEngine;

public class FlyAway : FlyBase
{
    [SerializeField] private float safeDistance = 10f;
    [SerializeField] private float floatHeight = 5f;
    private void FixedUpdate()
    {
        if (!target) return;
        if (Vector2.Distance(transform.position, target.position) < distanceToStop)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.fixedDeltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) > safeDistance)
        {
            var ray = new Ray(transform.position, Vector3.down);
            var hit = Physics2D.Raycast(ray.origin, ray.direction, floatHeight, LayerMask.GetMask("Ground"));
            if (!hit.collider || hit.collider.gameObject.layer != LayerMask.NameToLayer("Ground"))
            {
                transform.position = Vector2.MoveTowards(transform.position, transform.position + Vector3.down, speed * Time.fixedDeltaTime);
            }
        }
    }
}
