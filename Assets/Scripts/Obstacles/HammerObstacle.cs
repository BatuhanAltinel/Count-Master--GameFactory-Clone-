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

        if(transform.rotation.eulerAngles.x >= 86)
        {
            moveSpeed = -45;
        }
        if(transform.rotation.eulerAngles.x <= 10)
        {
            moveSpeed = 45;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        OnDestroyObject(other.gameObject);
    }

    
}
