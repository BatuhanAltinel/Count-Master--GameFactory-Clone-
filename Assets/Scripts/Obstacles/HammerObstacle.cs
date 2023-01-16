using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerObstacle : Obstacle
{
    void Update()
    {
        OnMove();
    }

    public override void OnMove()
    {
        transform.Rotate(moveSpeed * Time.deltaTime,0,0);

        if(transform.rotation.eulerAngles.x >= 85)
        {
            moveSpeed = -15;
        }
        if(transform.rotation.eulerAngles.x <= 18)
        {
            moveSpeed = 75;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        OnDestroyObject(other.gameObject);
    }

    
}
