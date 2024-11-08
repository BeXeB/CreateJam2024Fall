using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturableEnemy : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;
    
    private void Awake()
    {
        if (enemyController == null)
        {
            enemyController = GetComponent<EnemyController>();
        }
    }
    
    public void StartCapture()
    {
        //freeze the enemy
    }
    
    public void StopCapture()
    {
        //unfreeze the enemy
    }
    
    public void EndCapture()
    {
        enemyController.TakeDamage(1);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        //stun player 
    }
}
