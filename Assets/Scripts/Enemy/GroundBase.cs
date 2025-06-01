using UnityEngine;

public class GroundBase : MonoBehaviour
{
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float stoppingDistance = 1f;
    protected Transform target;
    protected Rigidbody2D rb;

    protected void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    
    protected void Update()
    {
        // Flip the sprite based on the direction of the player
        float horizontalMovement = target.position.x - transform.position.x;
        if (horizontalMovement < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (horizontalMovement > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
