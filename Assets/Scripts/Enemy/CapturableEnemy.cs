using UnityEngine;

public class CapturableEnemy : EnemyBase
{
    [SerializeField] private FlyBase flyBase;
    
    private void Awake()
    {
        if (!flyBase)
        {
            flyBase = GetComponent<FlyBase>();
        }
    }

    public void StartCapture()
    {
        flyBase.enabled = false;
        //TODO: Make the enemy follow the player while being captured
    }
    
    public void StopCapture()
    {
        flyBase.enabled = true;
        //TODO: Make the enemy stop following the player
    }
    
    public void EndCapture()
    {
        TakeDamage(health);
    }
}
