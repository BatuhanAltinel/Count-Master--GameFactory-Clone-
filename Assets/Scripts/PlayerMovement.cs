using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Touch _touch;
    [SerializeField] float touchMoveSpeed = 0.015f;

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
            // transform.GetChild(0).GetComponent<Player>().PlayWalkAnim();
            if(_touch.phase == TouchPhase.Moved)
            {
                if(GameManager.Instance.canMoveLeft)
                {
                    if(_touch.deltaPosition.x < 0)
                    {
                        GameManager.Instance.canMoveRight = true;
                        transform.position = new Vector3(transform.position.x + _touch.deltaPosition.x * touchMoveSpeed,
                                        transform.position.y, transform.position.z);
                    }
                }
                else
                {
                    Vector3 currentpos = transform.position;
                    if(transform.localPosition.x <= currentpos.x)
                        transform.position = new Vector3(currentpos.x,transform.position.y,transform.position.z);
                }

                if(GameManager.Instance.canMoveRight)
                {
                    if(_touch.deltaPosition.x >= 0)
                    {
                        GameManager.Instance.canMoveLeft = true;
                        transform.position = new Vector3(transform.position.x + _touch.deltaPosition.x * touchMoveSpeed,
                                        transform.position.y, transform.position.z);
                    }
                }
                else
                {
                    Vector3 currentpos = transform.position;
                    if(transform.localPosition.x >= currentpos.x)
                        transform.position = new Vector3(currentpos.x,transform.position.y,transform.position.z);
                }
                
            }
        }
    }
}
