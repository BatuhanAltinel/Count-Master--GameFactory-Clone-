using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Touch _touch;
    [SerializeField] float touchMoveSpeed = 0.02f;

    void Update()
    {
        TouchMovement();
    }

    void TouchMovement()
    {
        if(Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            GameManager.Instance.gameState = GameManager.GameStates.START;
            
            if(_touch.phase == TouchPhase.Moved)
            {
                if(GameManager.Instance.canMoveLeft)
                {
                    touchMoveSpeed = 0;
                    if(_touch.deltaPosition.x < 0)
                    {
                        touchMoveSpeed = 0.02f;
                        GameManager.Instance.canMoveRight = true;
                        transform.position = new Vector3(transform.position.x + _touch.deltaPosition.x * touchMoveSpeed,
                                        transform.position.y, transform.position.z);
                    }
                }

                if(GameManager.Instance.canMoveRight)
                {
                    touchMoveSpeed = 0;
                    if(_touch.deltaPosition.x >= 0)
                    {
                        touchMoveSpeed = 0.02f;
                        GameManager.Instance.canMoveLeft = true;
                        transform.position = new Vector3(transform.position.x + _touch.deltaPosition.x * touchMoveSpeed,
                                        transform.position.y, transform.position.z);
                    }
                }
                
            }
        }
    }
}
