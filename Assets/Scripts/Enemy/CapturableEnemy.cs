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

    public void StartCapture(Transform player)
    {
        flyBase.SetIsBeingCaptured(true);
        flyBase.CalculatePositionDiff();
    }
    
    public void StopCapture()
    {
        flyBase.SetIsBeingCaptured(false);
    }
    
    
    
    public void EndCapture()
    {
        TakeDamage(health);
    }
}
