using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected int health = 1;
    [SerializeField] protected float stunDuration = 1f;
    [SerializeField] protected int scoreValue = 1;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        AudioMananger.instance.PlayAudioClip("ZombieDead");
        PlayerStats.instance.AddScore(scoreValue, false);
        Destroy(gameObject);
    }
    
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        var pm = other.gameObject.GetComponent<PlayerMovement>();
        if (pm != null)
        {
            PlayerStats.instance.AddScore(0, true);
            pm.StartStun(stunDuration);
        }
    }
}
