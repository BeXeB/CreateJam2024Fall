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
        flyBase.SetIsBeingCaptured(true);
        flyBase.CalculatePositionDiff();
        flyBase.DisablePathfinding();
    }
    
    public void StopCapture()
    {
        flyBase.SetIsBeingCaptured(false);
        flyBase.EnablePathfinding();
    }
    
    public void EndCapture()
    {
        TakeDamage(health);
        AudioMananger.instance.PlayAudioClip("GhostDead");
    }
}
