using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransformMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();   
    }
    void MoveForward()
    {
        if(GameManager.Instance.gameState == GameManager.GameStates.START)
        {
            moveSpeed = 15f;
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if(GameManager.Instance.gameState == GameManager.GameStates.ATTACK)
        {
            moveSpeed = 0.1f;
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
            
    }
}
