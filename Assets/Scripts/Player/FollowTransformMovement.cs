using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransformMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 18f;

    void Update()
    {
        MoveForward();   
    }

    void MoveForward()
    {
        if(GameManager.Instance.gameState == GameManager.GameStates.START ||
            GameManager.Instance.gameState == GameManager.GameStates.END )
        {
            moveSpeed = 18f;
        }
        else if(GameManager.Instance.gameState == GameManager.GameStates.ATTACK)
        {
            moveSpeed = 0.5f;
        }
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
