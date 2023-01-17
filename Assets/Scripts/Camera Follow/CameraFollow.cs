using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera cam;
    [SerializeField] Transform followTransform;
    [SerializeField] Vector3 offSet;
    [SerializeField] float moveSpeed = 1.2f;
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(GameManager.Instance.gameState == GameManager.GameStates.START)
        {
            CameraNormalFollow();
        }else if(GameManager.Instance.gameState == GameManager.GameStates.ATTACK)
        {
            OnAttackCameraFollow();
        }
    }

    void CameraNormalFollow()
    {
        offSet = new Vector3(0,27.3f,-20.6f);
        transform.position = Vector3.Lerp(transform.position,followTransform.position + offSet,moveSpeed * Time.deltaTime);
    }
    void OnAttackCameraFollow()
    {
        offSet = new Vector3(0,18,-19.6f);
        transform.position = Vector3.Lerp(transform.position,followTransform.position + offSet,moveSpeed * Time.deltaTime);
    }
}
