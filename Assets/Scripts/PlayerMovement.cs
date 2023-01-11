using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Touch _touch;
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] float touchMoveSpeed = 0.02f;
    bool canSlide = true;

    void Update()
    {
        TouchMovement();
        MoveForward();
    }

    void TouchMovement()
    {
        if(Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            GameManager.gameManager.canMove = true;

            if(_touch.phase == TouchPhase.Moved)
            {
                if(!GameManager.gameManager.canMoveLeft)
                {
                    if(_touch.deltaPosition.x > 0)
                    {
                        transform.position = new Vector3(transform.position.x + _touch.deltaPosition.x * touchMoveSpeed,
                                        transform.position.y, transform.position.z);
                    }
                }
                if(!GameManager.gameManager.canMoveRight)
                {
                    if(_touch.deltaPosition.x < 0)
                    {
                        transform.position = new Vector3(transform.position.x + _touch.deltaPosition.x * touchMoveSpeed,
                                        transform.position.y, transform.position.z);
                    }
                }
                
            }
        }
    }
    void MoveForward()
    {
        if(GameManager.gameManager.canMove)
        {
            transform.Translate(Vector3.forward *_moveSpeed* Time.deltaTime);
        }
    }
}
