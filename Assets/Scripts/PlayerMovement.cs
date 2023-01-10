using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Touch _touch;
    [HideInInspector] public bool canMove;
    [HideInInspector] public bool canMoveRight = true;
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] float touchMoveSpeed = 0.02f;
    void Start()
    {
        
    }

    // Update is called once per frame
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
            canMove = true;
            if(_touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + _touch.deltaPosition.x * touchMoveSpeed,
                                        transform.position.y, transform.position.z);
            }
        }
    }
    void MoveForward()
    {
        if(canMove)
        {
            transform.Translate(Vector3.forward *_moveSpeed* Time.deltaTime);
        }
    }
}
