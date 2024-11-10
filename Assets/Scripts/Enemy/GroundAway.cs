using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAway : GroundBase
{
    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) < stoppingDistance)
        {
            rb.position = Vector2.MoveTowards(rb.position, new Vector2(target.position.x, rb.position.y), -speed * Time.fixedDeltaTime);
        }
    }
}
