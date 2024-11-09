using UnityEngine;

public class KillableEnemy : EnemyBase
{
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        if (other.contacts[0].normal.y < -0.5f)
        {
            TakeDamage(1);
        }
        else
        {
            AudioMananger.instance.PlayAudioClip("Zombie");
            base.OnCollisionEnter2D(other);
        }
    }
}
