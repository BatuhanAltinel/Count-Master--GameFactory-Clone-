using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : Obstacle
{
    void Update()
    {
        OnMove();
    }

    public override void OnMove()
    {
        moveSpeed = 75f;
        transform.Rotate(Vector3.up * moveSpeed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        OnDestroyObject(other.gameObject);
    }
}
