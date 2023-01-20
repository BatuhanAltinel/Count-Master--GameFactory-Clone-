using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Touch _touch;
    [SerializeField] float touchMoveSpeed = 0.02f;
    bool isGameStarted = false;

    void Update()
    {
        TouchMovement();
    }

    void TouchMovement()
    {
        if(Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            UIManager.instance.InActiveSlideBar();
            if(!isGameStarted)
            {
                GameManager.Instance.gameState = GameManager.GameStates.START;
                transform.GetChild(0).GetComponent<Player>().PlayWalkAnim();
                isGameStarted = true;
            }
            
            if(_touch.phase == TouchPhase.Moved && GameManager.Instance.gameState == GameManager.GameStates.START)
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
                
            }else if(_touch.phase == TouchPhase.Moved && GameManager.Instance.gameState == GameManager.GameStates.ATTACK)
            {
                Vector3 tarPos = GameManager.Instance.targetTransform.position;
                Vector3 dir = (tarPos - transform.position).normalized;
                transform.Translate(dir * Time.deltaTime * 0.1f);
            }
        }

    }


    
}
