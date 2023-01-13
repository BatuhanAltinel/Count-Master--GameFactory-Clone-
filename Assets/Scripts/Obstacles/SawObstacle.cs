using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawObstacle : Obstacle
{
    Vector3 targetPos;
    float targetXPoint = -14f;
    public float timeToMove = 10f;
    float elapsedTime = 0;
    void Start()
    {
        targetPos = new Vector3(targetXPoint,transform.position.y,transform.position.z);
    }
    void Update()
    {
        OnMove();
    }

    public override void OnMove()
    {
        
        elapsedTime += Time.deltaTime;

        float t = Mathf.Clamp01(elapsedTime/timeToMove);

        transform.position = Vector3.Lerp(transform.position,targetPos,t);

        if(Vector3.Distance(transform.position,targetPos) < 0.1f)
        {
            targetPos.x = -targetXPoint;
            targetXPoint = -targetXPoint;
            elapsedTime = 0;
        }   
            
    }

    void OnTriggerEnter(Collider other)
    {
        OnDestroyObject(other.gameObject);
    }
}
