using UnityEngine;

public class GroundBase : MonoBehaviour
{
    [SerializeField] protected float speed = 1f;
    [SerializeField] protected float stoppingDistance = 1f;
    protected Transform target;
    protected Rigidbody2D rb;

    protected void Awake()
    {
        target = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
}
