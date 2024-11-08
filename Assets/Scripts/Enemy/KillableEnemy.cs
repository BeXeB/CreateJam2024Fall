using UnityEngine;

public class KillableEnemy : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;

    private void Awake()
    {
        if (enemyController == null)
        {
            enemyController = GetComponent<EnemyController>();
        }
    }
    
    private void TakeDamage(int damage)
    {
        enemyController.TakeDamage(damage);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        if (other.contacts[0].normal.y < -0.5f)
        {
            TakeDamage(1);
        }
        else
        {
            //stun player
        }
    }
}
