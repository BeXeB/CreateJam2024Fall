using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyBase : MonoBehaviour
{
    [SerializeField] protected float distanceToStop = 1f;
    [SerializeField] protected float aggroRange = 5f;
    [SerializeField] protected float floatHeight = 5f;
    protected bool isBeingCaptured;
    protected Transform target;
    protected Vector3 positionDiff;
    protected NavMeshAgent agent;
    
    public void SetIsBeingCaptured(bool value)
    {
        isBeingCaptured = value;
    }
    
    public void CalculatePositionDiff()
    {
        positionDiff = target.position - transform.position;
    }
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        var horizontalMovement = agent.velocity.x;
        if (horizontalMovement < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (horizontalMovement > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void EnablePathfinding()
    {
        agent.enabled = true;
    }
    
    public void DisablePathfinding()
    {
        agent.enabled = false;
    }
}
