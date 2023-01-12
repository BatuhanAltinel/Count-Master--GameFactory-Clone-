using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerObstacle : MonoBehaviour
{
    public float moveSpeed = 1;

    void Update()
    {
        MoveUpAndDown();
    }

    void MoveUpAndDown()
    {
        transform.Rotate(moveSpeed * Time.deltaTime,0,0);

        if(transform.rotation.eulerAngles.x >= 88)
        {
            moveSpeed = -30;
        }
        if(transform.rotation.eulerAngles.x <= 2)
        {
            moveSpeed = 30;
        }
    }
}
