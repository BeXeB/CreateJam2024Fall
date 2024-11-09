using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundAway : GroundBase
{
    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < stoppingDistance)
        {
            // transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), -speed * Time.deltaTime);
            rb.position = Vector2.MoveTowards(rb.position, new Vector2(target.position.x, rb.position.y), -speed * Time.deltaTime);
        }
    }
}
