using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBase : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float distanceToStop = 1f;
    [SerializeField] protected float aggroRange = 5f;
    
    protected Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
